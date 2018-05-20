using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Client : Form
    {
        Socket server;
        IPEndPoint IP;
        byte[] data;
        string key;
        int sec = 0;
        int time;
        string padding;
        bool check;
        public Client()
        {
            InitializeComponent();
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10000);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        //AES-256 Encrypt
        private string Encrypt256(string text, string key, string IV)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = Encoding.ASCII.GetBytes(key);
            aes.IV = Encoding.ASCII.GetBytes(IV);
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.None;

            // Convert string to byte array
            byte[] src = Encoding.Default.GetBytes(text);

            // encryption
            using (ICryptoTransform encrypt = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                // Convert byte array to Base64 strings
                return Convert.ToBase64String(dest);
            }
        }

        //AES-256 Decrypt
        private string Decrypt256(string text, string key, string IV)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.ASCII.GetBytes(IV);
            aes.Key = Encoding.ASCII.GetBytes(key);
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.None;

            // Convert Base64 strings to byte array
            byte[] src = System.Convert.FromBase64String(text);

            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Default.GetString(dest);
            }
        }

        //MD5 Hash
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5p = new MD5CryptoServiceProvider();
            byte[] bytes = md5p.ComputeHash(new UTF8Encoding().GetBytes(input));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        //Trao đổi key
        public void ExchangePublicKey()
        {
            data = new byte[1024];
            Random rd = new Random();
            int recv = server.Receive(data, data.Length, SocketFlags.None);
            string k = Encoding.ASCII.GetString(data, 0, recv);
            string[] tamp = k.Split(new char[] { ',' });
            txtP.Text = tamp[0];
            txtG.Text = tamp[1];
            string PA = tamp[2];

            int p = int.Parse(tamp[0]), g = int.Parse(tamp[1]);
            int b = rd.Next(1, 10);

            int A = int.Parse(PA);

            int B = (int)Math.Pow(g, b) % p;
            data = new byte[1024];
            data = Encoding.ASCII.GetBytes(B.ToString());
            server.Send(data, data.Length, SocketFlags.None);


            int s = (int)Math.Pow(A, b) % p;

            key = MD5Hash(s.ToString());
            txtKey.Text = key;

            time += 1;
            txtTime.Text = time.ToString();
        }

        //Hàm xử lí kết nối
        public void HandleConnection()
        {
            while (true)
            {
                byte[] data = new byte[1024 * 50];
                int recv = server.Receive(data, SocketFlags.None);

                string k = Encoding.ASCII.GetString(data, 0, recv);

                if (k == "timeout")
                {
                    data = Encoding.ASCII.GetBytes("timeout");
                    server.Send(data, data.Length, SocketFlags.None);
                    ExchangePublicKey();

                }
                else
                {
                    string[] tamp = k.Split(new char[] { ';' });
                    string decrypt = Decrypt256(tamp[1], txtKey.Text, tamp[0]);
                    int L = tamp[2].Length;
                    string hash = tamp[3];
                    if (MD5Hash(decrypt.Substring(0, decrypt.Length - L) + key) == hash)
                        check = true;
                    else check = false;
                    if (check == true)
                    {
                        txtResult.Text = k;
                        txtIV.Text = tamp[0];
                        txtHash.Text = tamp[1];
                        txtPadding.Text = tamp[2];
                        lbMessage.Items.Add("<Server> : " + decrypt.Substring(0, decrypt.Length - L));
                    }
                    else
                    {
                        txtResult.Text = k;
                        txtIV.Text = tamp[0];
                        txtHash.Text = tamp[1];
                        txtPadding.Text = tamp[2];
                        lbMessage.Items.Add("<Server> : Tin nhắn đã bị thay đổi!");
                    }
                }

            }
        }

        //Sinh ngẫu nhiên IV
        public string RandomIV()
        {
            Random rd = new Random();
            string str = "";
            for (int i = 0; i < 16; i++)
            {
                int n = rd.Next(0, 10);
                str = str + n.ToString();
            }
            return str;
        }

        //Sinh ngẫu nhiên kí tự
        private string RandomString(int size)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(60, 122)));
                sb.Append(c);
            }

            return sb.ToString();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server.Connect(IP);
            EndPoint ep = (EndPoint)IP;
            lbMessage.Items.Add("Kết nối thành công");
            lbMessage.Items.Add("----------------------------------------------------------");
            ExchangePublicKey();

            StartTimer();

            Thread thr = new Thread(new ThreadStart(HandleConnection));
            thr.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string dulieu = "";
            string iv = RandomIV();
            
            
            if (txtMessage.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống nội dung!!");
                return;
            }
            else
            {
                if (txtMessage.Text.Length % 16 != 0)
                {

                    int length = 16 - txtMessage.Text.Length % 16;


                    padding = RandomString(length);

                    string message = txtMessage.Text + padding;
                    dulieu = Encrypt256(message, key, iv);
                }
                else
                {
                    dulieu = Encrypt256(txtMessage.Text, key, iv);
                }
            }
            lbMessage.Items.Add("<Me> : " + txtMessage.Text);

            string check = txtMessage.Text + key;
            string hash = MD5Hash(check);

            dulieu = iv + ";" + dulieu + ";" + padding +";"+ hash;
            data = new byte[1024];
            data = Encoding.ASCII.GetBytes(dulieu);
            server.Send(data, data.Length, SocketFlags.None);

            txtMessage.Text = "";

        }

        private void btnSendNoise_Click(object sender, EventArgs e)
        {
            string dulieu = "";
            string iv = RandomIV();
            
            string noise = RandomString(5);
            if (txtMessage.Text.Length == 0)
                MessageBox.Show("Không được để trống nội dung!!");
            else
            {
                if (txtMessage.Text.Length % 16 != 0)
                {

                    int length = 16 - (txtMessage.Text.Length + noise.Length) % 16;


                    padding = RandomString(length);

                    string message = txtMessage.Text + noise + padding;
                    dulieu = Encrypt256(message, key, iv);
                }
                else
                {
                    dulieu = Encrypt256(txtMessage.Text, key, iv);
                }
            }
            lbMessage.Items.Add("<Me> : " + txtMessage.Text);
            string check = txtMessage.Text + key;
            string hash = MD5Hash(check);

            dulieu = iv + ";" + dulieu + ";" + padding +";"+ hash;
            data = Encoding.ASCII.GetBytes(dulieu);
            server.Send(data, data.Length, SocketFlags.None);

            txtMessage.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec = sec + 1;
            
            progressBar1.Value = sec;
            progressBar1.Step = 1;

            progressBar1.Maximum = 21;
            
            progressBar1.PerformStep();
            label8.Text = sec.ToString();
            if (sec == 20)
            {

                label9.Visible = true;
                btnSend.Enabled = false;
                btnSendNoise.Enabled = false;
                sec = 0;
                timer1.Stop();
                StartTimer();
            }
            else
            {
                if (sec < 2)
                {
                    label10.Visible = true;
                    label9.Visible = false;
                    btnSend.Enabled = true;
                    btnSendNoise.Enabled = true;
                }
                else
                {
                    label10.Visible = false;
                }
            }

        }

        public void StartTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }
    }
}