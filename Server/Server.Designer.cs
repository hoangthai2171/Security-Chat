namespace Server
{
    partial class Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbMessage = new System.Windows.Forms.ListBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSendNoise = new System.Windows.Forms.Button();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtHash = new System.Windows.Forms.TextBox();
            this.txtPadding = new System.Windows.Forms.TextBox();
            this.txtIV = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupbox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMessage
            // 
            this.lbMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbMessage.FormattingEnabled = true;
            this.lbMessage.Location = new System.Drawing.Point(12, 12);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(444, 355);
            this.lbMessage.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMessage.Location = new System.Drawing.Point(12, 373);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(444, 65);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(463, 375);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(81, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSendNoise
            // 
            this.btnSendNoise.Location = new System.Drawing.Point(463, 404);
            this.btnSendNoise.Name = "btnSendNoise";
            this.btnSendNoise.Size = new System.Drawing.Size(81, 34);
            this.btnSendNoise.TabIndex = 3;
            this.btnSendNoise.Text = "Send + Noise";
            this.btnSendNoise.UseVisualStyleBackColor = true;
            this.btnSendNoise.Click += new System.EventHandler(this.btnSendNoise_Click);
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.txtTime);
            this.groupbox1.Controls.Add(this.label11);
            this.groupbox1.Controls.Add(this.progressBar1);
            this.groupbox1.Controls.Add(this.label8);
            this.groupbox1.Controls.Add(this.txtG);
            this.groupbox1.Controls.Add(this.txtP);
            this.groupbox1.Controls.Add(this.label7);
            this.groupbox1.Controls.Add(this.label6);
            this.groupbox1.Controls.Add(this.label5);
            this.groupbox1.Controls.Add(this.label4);
            this.groupbox1.Controls.Add(this.label3);
            this.groupbox1.Controls.Add(this.label2);
            this.groupbox1.Controls.Add(this.label1);
            this.groupbox1.Controls.Add(this.txtResult);
            this.groupbox1.Controls.Add(this.txtHash);
            this.groupbox1.Controls.Add(this.txtPadding);
            this.groupbox1.Controls.Add(this.txtIV);
            this.groupbox1.Controls.Add(this.txtKey);
            this.groupbox1.Location = new System.Drawing.Point(475, 12);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(313, 355);
            this.groupbox1.TabIndex = 4;
            this.groupbox1.TabStop = false;
            this.groupbox1.Text = "Tools";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(101, 302);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(21, 20);
            this.txtTime.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(6, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Số lần trao đổi key:";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(6, 326);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(269, 23);
            this.progressBar1.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(279, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 24);
            this.label8.TabIndex = 18;
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(214, 283);
            this.txtG.Name = "txtG";
            this.txtG.ReadOnly = true;
            this.txtG.Size = new System.Drawing.Size(25, 20);
            this.txtG.TabIndex = 17;
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(142, 283);
            this.txtP.Name = "txtP";
            this.txtP.ReadOnly = true;
            this.txtP.Size = new System.Drawing.Size(25, 20);
            this.txtP.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(192, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "g:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "p:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Result";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hash";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Padding";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "IV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(73, 257);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(234, 20);
            this.txtResult.TabIndex = 4;
            // 
            // txtHash
            // 
            this.txtHash.Location = new System.Drawing.Point(73, 196);
            this.txtHash.Name = "txtHash";
            this.txtHash.ReadOnly = true;
            this.txtHash.Size = new System.Drawing.Size(234, 20);
            this.txtHash.TabIndex = 3;
            // 
            // txtPadding
            // 
            this.txtPadding.Location = new System.Drawing.Point(73, 140);
            this.txtPadding.Name = "txtPadding";
            this.txtPadding.ReadOnly = true;
            this.txtPadding.Size = new System.Drawing.Size(234, 20);
            this.txtPadding.TabIndex = 2;
            // 
            // txtIV
            // 
            this.txtIV.Location = new System.Drawing.Point(73, 85);
            this.txtIV.Name = "txtIV";
            this.txtIV.ReadOnly = true;
            this.txtIV.Size = new System.Drawing.Size(234, 20);
            this.txtIV.TabIndex = 1;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(73, 28);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(234, 20);
            this.txtKey.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(550, 375);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(247, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Hết thời gian, đang trao đổi key lại";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkViolet;
            this.label10.Location = new System.Drawing.Point(550, 410);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Trao đổi key thành công!";
            this.label10.Visible = false;
            // 
            // Server
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupbox1);
            this.Controls.Add(this.btnSendNoise);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lbMessage);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.MaximizeBox = false;
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupbox1.ResumeLayout(false);
            this.groupbox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSendNoise;
        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtHash;
        private System.Windows.Forms.TextBox txtPadding;
        private System.Windows.Forms.TextBox txtIV;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTime;
    }
}

