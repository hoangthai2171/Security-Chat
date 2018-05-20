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

namespace Server
{
    public partial class Server : Form
    {
        IPEndPoint IP;
        Socket server;
        Socket client;
        byte[] data;
        string key;
        int time;
        string padding;
        string ipAddress;
        bool check;
        int sec = 0;
        public Server()
        {
            InitializeComponent();
            IP = new IPEndPoint(IPAddress.Any, 10000);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
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
            Random r = new Random();
            int p = r.Next(2, 10);
            int g = r.Next(2, 10);
            txtP.Text = p.ToString();
            txtG.Text = g.ToString();

            int a = r.Next(1, 10);
            int A = (int)Math.Pow(g, a) % p;

            string t = p + "," + g + "," + A;
            data = Encoding.ASCII.GetBytes(t);
            client.Send(data, data.Length, SocketFlags.None);

            data = new byte[1024];
            int recv = client.Receive(data, data.Length, SocketFlags.None);
            string k = Encoding.ASCII.GetString(data, 0, recv);

            int B = int.Parse(k);
            int s = (int)Math.Pow(B, a) % p;

            key = MD5Hash(s.ToString());
            txtKey.Text = key;

            time += 1;
            txtTime.Text = time.ToString();
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

        //Hàm sử lí kết nối
        public void HandleConnection()
        {
            while (true)
            {
                byte[] data = new byte[1024*50];
                int recv = client.Receive(data, SocketFlags.None);
                string k = Encoding.ASCII.GetString(data, 0, recv);
                
                    if (k == "timeout")
                        ExchangePublicKey();
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
                            lbMessage.Items.Add("<Client> : " + decrypt.Substring(0, decrypt.Length - L));
                        }
                        else
                        {
                            txtResult.Text = k;
                            txtIV.Text = tamp[0];
                            txtHash.Text = tamp[1];
                            txtPadding.Text = tamp[2];
                            lbMessage.Items.Add("<Client> : Tin nhắn đã bị thay đổi!");
                        }
                    }
                
            
            }
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

        //Lấy địa chỉ IPv4
        public string GetipAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipAddress = Convert.ToString(IP);
                }
            }
            return ipAddress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server.Bind(IP);
            server.Listen(10);
            lbMessage.Items.Add("Đang chờ client...");
            client = server.Accept();

            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
            lbMessage.Items.Add("Đã kết nối với client: " + GetipAddress());
            lbMessage.Items.Add("----------------------------------------------------------");
            ExchangePublicKey();

            StartTimer();
           
            Thread thr = new Thread(new ThreadStart(HandleConnection));
            thr.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
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
            data = Encoding.ASCII.GetBytes(dulieu);
            client.Send(data, data.Length, SocketFlags.None);

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
            client.Send(data, data.Length, SocketFlags.None);

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
                data = new byte[1024];
                data = Encoding.ASCII.GetBytes("timeout");
                client.Send(data, data.Length, SocketFlags.None);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            data = new byte[1024];
            data = Encoding.ASCII.GetBytes("exit");
            client.Send(data,0,SocketFlags.None);
        }
    }
}
