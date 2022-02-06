namespace exSnake
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.entry_Btn = new System.Windows.Forms.Button();
            this.lb_chatroom = new System.Windows.Forms.ListBox();
            this.port_TB = new System.Windows.Forms.TextBox();
            this.nickname_TB = new System.Windows.Forms.TextBox();
            this.serverIP_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // entry_Btn
            // 
            this.entry_Btn.Location = new System.Drawing.Point(710, 62);
            this.entry_Btn.Name = "entry_Btn";
            this.entry_Btn.Size = new System.Drawing.Size(119, 33);
            this.entry_Btn.TabIndex = 17;
            this.entry_Btn.Text = "Enter";
            this.entry_Btn.UseVisualStyleBackColor = true;
            this.entry_Btn.Click += new System.EventHandler(this.entry_Btn_Click);
            // 
            // lb_chatroom
            // 
            this.lb_chatroom.FormattingEnabled = true;
            this.lb_chatroom.ItemHeight = 12;
            this.lb_chatroom.Location = new System.Drawing.Point(518, 150);
            this.lb_chatroom.Name = "lb_chatroom";
            this.lb_chatroom.Size = new System.Drawing.Size(311, 184);
            this.lb_chatroom.TabIndex = 16;
            // 
            // port_TB
            // 
            this.port_TB.Location = new System.Drawing.Point(730, 30);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(100, 22);
            this.port_TB.TabIndex = 14;
            this.port_TB.Text = "5236";
            // 
            // nickname_TB
            // 
            this.nickname_TB.Location = new System.Drawing.Point(573, 69);
            this.nickname_TB.Name = "nickname_TB";
            this.nickname_TB.Size = new System.Drawing.Size(100, 22);
            this.nickname_TB.TabIndex = 13;
            // 
            // serverIP_TB
            // 
            this.serverIP_TB.Location = new System.Drawing.Point(573, 30);
            this.serverIP_TB.Name = "serverIP_TB";
            this.serverIP_TB.Size = new System.Drawing.Size(100, 22);
            this.serverIP_TB.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(697, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(514, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nickname:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server IP:";
            // 
            // timer1
            // 
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(59, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(515, 407);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Current_score:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.Tan;
            this.BtnReset.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnReset.ForeColor = System.Drawing.Color.Black;
            this.BtnReset.Location = new System.Drawing.Point(518, 346);
            this.BtnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(92, 30);
            this.BtnReset.TabIndex = 21;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.Wheat;
            this.BtnStart.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnStart.Location = new System.Drawing.Point(632, 347);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(92, 30);
            this.BtnStart.TabIndex = 22;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(515, 115);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "System_message:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 442);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.entry_Btn);
            this.Controls.Add(this.lb_chatroom);
            this.Controls.Add(this.port_TB);
            this.Controls.Add(this.nickname_TB);
            this.Controls.Add(this.serverIP_TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button entry_Btn;
        private System.Windows.Forms.ListBox lb_chatroom;
        private System.Windows.Forms.TextBox port_TB;
        private System.Windows.Forms.TextBox nickname_TB;
        private System.Windows.Forms.TextBox serverIP_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label label7;
    }
}

