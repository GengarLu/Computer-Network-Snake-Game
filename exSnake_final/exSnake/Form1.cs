using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace exSnake
{
    public partial class Form1 : Form
    {
        #region
        public Point[] SnkLct = new Point[500]; //Lct=Location
        public int SnkLen;
        public int speed = 150;
        public int SnkDrt; //U=1=上 ; R=2=右 ; D=3=下 ; L=4=左
        public Point FoodLct = new Point();
        public int score = 0;
        public bool pause;
        #endregion

        #region
        Socket socketClient;
        Thread listenThread;
        IPEndPoint EP;
        byte[] data = new byte[10024];
        bool IsConnect;
        bool isMessage2ALL = true;
        #endregion

        String player = "";                                  //通訊物件

        public Form1()
        {
            InitializeComponent();
        }

        private string MyIP()
        {
            string hn = Dns.GetHostName();
            IPAddress[] ip = Dns.GetHostEntry(hn).AddressList;
            foreach (IPAddress it in ip)
            {
                if (it.AddressFamily == AddressFamily.InterNetwork)
                {
                    return it.ToString();
                }
            }
            return "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            this.Text += MyIP();
            serverIP_TB.Text = MyIP();
            //Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (entry_Btn.Enabled == false)
            {
                socketSend("logout," + nickname_TB.Text + ",");
                socketClient.Close();
            }
        }

        public void socketSend(string sendData)
        {
            if (IsConnect)
            {
                try
                {
                    socketClient.Send(Encoding.Default.GetBytes(sendData));
                    //將要傳送的 string 資料 轉換成 byte 傳送出去
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                lb_chatroom.Items.Add("遊戲已斷線");
            }
        }

        private void entry_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (serverIP_TB.Text != "" && port_TB.Text != "" && nickname_TB.Text != "")      //checking TB != ""
                {
                    socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    EP = new IPEndPoint(IPAddress.Parse(serverIP_TB.Text), int.Parse(port_TB.Text));
                    socketClient.Connect(EP);
                    listenThread = new Thread(socketReceive);
                    listenThread.IsBackground = true;
                    listenThread.Start();
                    IsConnect = true;
                    socketSend("login," + nickname_TB.Text + ",");
                    serverIP_TB.Enabled = false;
                    port_TB.Enabled = false;
                    nickname_TB.Enabled = false;
                    entry_Btn.Enabled = false;
                }
                else
                {
                    MessageBox.Show("請輸入完整資訊");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void socketReceive()
        {
            int recvLength = 0;
            try
            {
                do
                {
                    recvLength = socketClient.Receive(data);
                    if (recvLength > 0)
                    {
                        Receive(Encoding.Default.GetString(data).Trim());
                        //將接收到的 byte 資料 轉換成 string 並呼叫 receive 方法
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Receive(string recvData) //接收並判斷資料
        {
            try
            {
                char token = ',';
                string[] pt = recvData.Split(token);  //將接收資料用 , 切割並存入陣列
                switch (pt[0])      //使用陣列中第一筆資料溝通
                {
                    case "message":
                        lb_chatroom.Items.Add(pt[1]);
                        break;
                    case "DM":
                        lb_chatroom.Items.Add(pt[1]);
                        break;
                    case "deny":
                        lb_chatroom.Items.Add("[System] : 暱稱重複，請重新輸入");

                        serverIP_TB.Enabled = true;
                        port_TB.Enabled = true;
                        nickname_TB.Enabled = true;
                        entry_Btn.Enabled = true;
                        break;
                    case "list":
                        lb_chatroom.Items.Clear();
                        for (int i = 1; i < pt.Length; i++)
                        {
                            lb_chatroom.Items.Add(pt[i]);
                        }
                        break;
                    case "ID":
                        if (player == "")
                        {
                            lb_chatroom.Items.Add(pt[2]);
                            player = pt[2];
                            socketSend("playerReady,");
                        }
                        break;
                    case "Compare":
                        lb_chatroom.Items.Add(pt[1] + pt[2]);
                        break;
                    case "GameStart":
                        //speed = 150;
                        //timer1.Enabled = true;
                        //score = 0;
                        lb_chatroom.Items.Add("Preparing...");
                        break;
                } // end switch

                Array.Clear(data, 0, data.Length);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } // end try-catch
        }

        //private void Start()
        //{
        //    Init();
        //    for (int i = 1; i <= SnkLen; i++)
        //    {
        //        Drawshape(SnkLct[i].X, SnkLct[i].Y);
        //    }
        //    timer1.Interval = speed;
        //    timer1.Enabled = true;
        //    Food();
        //}

        private void Init()
        {
            score = 0;
            int start1 = 0;
            SnkLen = 5;
            for (int i = 5; i >= 1; i--)
            {
                SnkLct[i].X = start1;
                SnkLct[i].Y = 40;
                start1 += 20;
            }
            SnkDrt = 4;

            Random rnd = new Random();
            Point pt1 = new Point();
            pt1.X = rnd.Next(1, 20) * 20;
            pt1.Y = rnd.Next(1, 20) * 20;
            label4.Location = pt1;
        }

        private void Drawshape(int x, int y)
        {
            Graphics g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen1 = new Pen(Color.Blue, 1);
            SolidBrush brush1 = new SolidBrush(Color.SaddleBrown);
            g.DrawRectangle(pen1, x, y, 15, 15);
            g.FillRectangle(brush1, x, y, 15, 15);
        }

        private void Food()
        {
            Random rnd = new Random();
            Point pt1 = new Point();
            pt1.X = rnd.Next(1, 20) * 20;
            pt1.Y = rnd.Next(1, 20) * 20;
            label4.Location = pt1;
            FoodLct.X = pt1.X;
            FoodLct.Y = pt1.Y;
        }

        private bool Eated()
        {
            if (SnkLct[1].X == FoodLct.X && SnkLct[1].Y == FoodLct.Y)
            {
                SnkLen++;
                SnkLct[SnkLen].X = SnkLct[SnkLen - 1].X;
                SnkLct[SnkLen].Y = SnkLct[SnkLen - 1].Y;
                score += 10;
                label5.Text = "目前分數:" + score.ToString();
                return true;
            }
            else
                return false;
        }

        private bool Dead()
        {
            for (int i = 2; i <= SnkLen; i++)
            {
                if (SnkLct[1].X == FoodLct.X && SnkLct[1].Y == FoodLct.Y)
                {
                    return true;
                }
            }

            if (SnkLct[1].X > 430 || SnkLct[1].X < 0 || SnkLct[1].Y > 450 || SnkLct[1].Y < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Forward(int drc)
        {
            for (int i = SnkLen; i > 1; i--)
            {
                SnkLct[i].X = SnkLct[i - 1].X;
                SnkLct[i].Y = SnkLct[i - 1].Y;
            }
            if (drc == 1)
            {
                SnkLct[1].Y -= 20;
            }
            else if (drc == 4)
            {
                SnkLct[1].X += 20;
            }
            else if (drc == 2)
            {
                SnkLct[1].Y += 20;
            }
            else if (drc == 3)
            {
                SnkLct[1].X -= 20;
            }

            for (int i = 1; i <= SnkLen; i++)
            {
                Drawshape(SnkLct[i].X, SnkLct[i].Y);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Drawing.Graphics g;
            g = this.CreateGraphics();
            g.Clear(Color.Azure);
            Forward(SnkDrt);
            if (Eated())
            {
                Food();
            }
            if (Dead())
            {
                timer1.Enabled = false;
                if (isMessage2ALL)
                    socketSend("message2All," + nickname_TB.Text + " : " + "Dead!!!" + "Score:" + score + ",");
                socketSend("compare," + player + "," + score + ",");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                SnkDrt = 1;
            }
            if (e.KeyCode == Keys.D)
            {
                SnkDrt = 4;
            }
            if (e.KeyCode == Keys.S)
            {
                SnkDrt = 2;
            }
            if (e.KeyCode == Keys.A)
            {
                SnkDrt = 3;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            lb_chatroom.Items.Add(player + " want to have another game!");
            socketSend("reset,");
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            label5.Text = "目前分數:0";
            Init();
            for (int i = 1; i <= SnkLen; i++)
            {
                Drawshape(SnkLct[i].X, SnkLct[i].Y);
            }
            timer1.Interval = speed;
            timer1.Enabled = true;
            Food();
        }
    }
}
