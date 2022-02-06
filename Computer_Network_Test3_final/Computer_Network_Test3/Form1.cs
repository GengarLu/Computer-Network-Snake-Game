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
using System.Collections;

namespace Computer_Network_Test3
{
    public partial class Form1 : Form
    {
        #region
        TcpListener server;
        Hashtable HT = new Hashtable();
        Socket socketClient;
        Thread Th_Svr, Th_Clt;
        int[] playername = new int[2];
        int Playerready = 0;
        int score_1 = -1;
        int score_2 = -1;
        //int score_1 = 0;
        //int score_2 = 0;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
        }

        #region
        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Th_Svr = new Thread(ServerSub);
                Th_Svr.IsBackground = true;
                Th_Svr.Start();

                log_LB.Items.Add("伺服器Socket建立完成!");
                log_LB.Update();
                connectBtn.Enabled = false;
                ip_TB.Enabled = false;
                port_TB.Enabled = false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ServerSub()
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(ip_TB.Text), int.Parse(port_TB.Text));
            server = new TcpListener(EP);
            server.Start(100);

            while (true)
            {
                socketClient = server.AcceptSocket();
                Th_Clt = new Thread(listen);
                Th_Clt.IsBackground = true;
                Th_Clt.Start();
            }
        }

        #region
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.ExitThread();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void winner()
        {
            if (score_1 > score_2 && score_2 != -1)
            {
                sendAll("Compare," + "player1 ," + "win,");
            }
            if (score_1 < score_2 && score_1 != -1)
            {
                sendAll("Compare," + "player2 ," + "win,");
            }
            if (score_1 == -1)
            {
                sendAll("Compare," + "player1 ," + "still playing,");
            }
            if (score_2 == -1)
            {
                sendAll("Compare," + "player2 ," + "still playing,");
            }
            if (score_1 == score_2 && score_1 != -1 && score_2 != -1)
            {
                sendAll("Compare," + "Tie," + ",");
            }
        }

        private void listen()
        {
            Socket sck = socketClient;
            Thread Th = Th_Clt;
            string id = null;
            while (true)
            {
                byte[] B = new byte[1023];
                try
                {
                    int inLen = sck.Receive(B);
                    string str = Encoding.Default.GetString(B, 0, inLen);
                    string[] Msg = str.Split(',');
                    switch (Msg[0])
                    {
                        case "message2All":
                            //logLBAdd("MessageAll", Msg[1]);
                            log_LB.Items.Add("[MessageAll] : " + Msg[1]);
                            sendAll("message," + Msg[1]);
                            break;
                        case "compare":
                            if (Msg[1] == "player1")
                            {
                                score_1 = Int32.Parse(Msg[2]);
                            }
                            else if (Msg[1] == "player2")
                            {
                                score_2 = Int32.Parse(Msg[2]);
                            }
                            winner();
                            break;
                        case "reset":
                            Playerready += 1;
                            if (Playerready == 2)
                            {
                                score_1 = -1;
                                score_2 = -1;
                                sendAll("GameStart,");
                                Playerready = 0;
                                playername[0] = 0;
                                playername[1] = 1;
                            }
                            break;
                        case "playerReady":
                            Playerready += 1;
                            if (Playerready == 2)
                            {
                                sendAll("GameStart,");
                                Playerready = 0;
                                playername[0] = 0;
                                playername[1] = 1;
                            }
                            break;
                        case "login":
                            try
                            {
                                id = Msg[1];
                                HT.Add(id, sck);
                                onlineList_LB.Items.Add(id);
                                //sendAll("list," + id + ",");
                                logLBAdd("Login,", id);
                                sendAll(str);
                                if (playername[0] == 0 && playername[1] == 0)
                                {
                                    playername[0] = 1;
                                    sendAll("ID," + playername[0] + ",player1,");
                                }
                                else if (playername[0] == 1 && playername[1] == 0)
                                {
                                    playername[1] = 1;
                                    sendAll("ID," + playername[1] + ",player2,");
                                }
                            }
                            catch
                            {
                                SendTo("deny,", sck);
                            }
                            break;
                        case "logout":
                            HT.Remove(Msg[1]);
                            onlineList_LB.Items.Remove(Msg[1]);
                            sendAll(str);
                            Th.Abort();
                            break;
                        case "ctrl":
                            sendAll("ctrl," + Msg[1] + ",");
                            break;
                    }
                }
                catch
                {
                    logLBAdd("Crash", id);
                    sendAll("message," + id + "logout.");
                }
            }
        }
        #endregion

        #region

        private void logLBAdd(string type, string info)
        {
            log_LB.Items.Add("[" + type + "] : " + info);
        }
        #endregion

        #region
        private void sendAll(string str)
        {
            byte[] B = Encoding.Default.GetBytes(str);
            foreach (Socket s in HT.Values)
            {
                s.Send(B, 0, B.Length, SocketFlags.None);
            }
        }

        private void SendTo(string user, string str)
        {
            byte[] B = Encoding.Default.GetBytes(str);
            Socket sck = (Socket)HT[user];
            sck.Send(B, 0, B.Length, SocketFlags.None);
        }

        private void SendTo(string str, Socket sck)
        {
            byte[] B = Encoding.Default.GetBytes(str);
            sck.Send(B, 0, B.Length, SocketFlags.None);
        }
        #endregion

    }
}
