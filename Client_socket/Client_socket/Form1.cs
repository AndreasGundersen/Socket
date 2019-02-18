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

namespace Client_socket
{
    public partial class Form1 : Form
    {
        //client variables
        string serverIp = "localhost";
        int port = 8080;

        public Form1()
        {
            InitializeComponent();
           
            
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            //create client 
            TcpClient client = new TcpClient(serverIp, port);

            int byteCount = Encoding.ASCII.GetByteCount(Message.Text);

            byte[] sendData = new byte[byteCount];

            sendData = Encoding.ASCII.GetBytes(Message.Text);

            NetworkStream stream = client.GetStream();

            stream.Write(sendData, 0, sendData.Length);

            stream.Close();
            client.Close();
            



        }
    }
}
