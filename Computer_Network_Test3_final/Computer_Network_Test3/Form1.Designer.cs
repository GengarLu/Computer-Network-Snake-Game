
namespace Computer_Network_Test3
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
            this.ip_Lab = new System.Windows.Forms.Label();
            this.port_Lab = new System.Windows.Forms.Label();
            this.ip_TB = new System.Windows.Forms.TextBox();
            this.port_TB = new System.Windows.Forms.TextBox();
            this.onlineList_LB = new System.Windows.Forms.ListBox();
            this.log_LB = new System.Windows.Forms.ListBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ip_Lab
            // 
            this.ip_Lab.AutoSize = true;
            this.ip_Lab.Location = new System.Drawing.Point(24, 62);
            this.ip_Lab.Name = "ip_Lab";
            this.ip_Lab.Size = new System.Drawing.Size(18, 12);
            this.ip_Lab.TabIndex = 0;
            this.ip_Lab.Text = "IP:";
            // 
            // port_Lab
            // 
            this.port_Lab.AutoSize = true;
            this.port_Lab.Location = new System.Drawing.Point(191, 62);
            this.port_Lab.Name = "port_Lab";
            this.port_Lab.Size = new System.Drawing.Size(27, 12);
            this.port_Lab.TabIndex = 1;
            this.port_Lab.Text = "Port:";
            // 
            // ip_TB
            // 
            this.ip_TB.Location = new System.Drawing.Point(67, 59);
            this.ip_TB.Name = "ip_TB";
            this.ip_TB.Size = new System.Drawing.Size(100, 22);
            this.ip_TB.TabIndex = 2;
            this.ip_TB.Text = "127.0.0.1";
            // 
            // port_TB
            // 
            this.port_TB.Location = new System.Drawing.Point(237, 59);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(100, 22);
            this.port_TB.TabIndex = 3;
            this.port_TB.Text = "5236";
            // 
            // onlineList_LB
            // 
            this.onlineList_LB.FormattingEnabled = true;
            this.onlineList_LB.ItemHeight = 12;
            this.onlineList_LB.Location = new System.Drawing.Point(98, 185);
            this.onlineList_LB.Name = "onlineList_LB";
            this.onlineList_LB.Size = new System.Drawing.Size(202, 256);
            this.onlineList_LB.TabIndex = 4;
            this.onlineList_LB.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // log_LB
            // 
            this.log_LB.FormattingEnabled = true;
            this.log_LB.ItemHeight = 12;
            this.log_LB.Location = new System.Drawing.Point(401, 59);
            this.log_LB.Name = "log_LB";
            this.log_LB.Size = new System.Drawing.Size(328, 376);
            this.log_LB.TabIndex = 5;
            this.log_LB.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(114, 116);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(157, 37);
            this.connectBtn.TabIndex = 6;
            this.connectBtn.Text = "Establish a connection";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.log_LB);
            this.Controls.Add(this.onlineList_LB);
            this.Controls.Add(this.port_TB);
            this.Controls.Add(this.ip_TB);
            this.Controls.Add(this.port_Lab);
            this.Controls.Add(this.ip_Lab);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ip_Lab;
        private System.Windows.Forms.Label port_Lab;
        private System.Windows.Forms.TextBox ip_TB;
        private System.Windows.Forms.TextBox port_TB;
        private System.Windows.Forms.ListBox onlineList_LB;
        private System.Windows.Forms.ListBox log_LB;
        private System.Windows.Forms.Button connectBtn;
    }
}

