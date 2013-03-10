using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;


namespace WebSerwer.Model
{
    class StartClass
    { 
        private ListenClass _listener;

        public TcpListener Start(int port, TcpListener myListener)
        {
            try
            {
                myListener = new TcpListener(port);
                myListener.Start();
                Console.WriteLine("Web Server Running... Press ^C to Stop...");

               // Thread th = new Thread(new ThreadStart(StartListen));
               // th.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("An Exception Occurred while Listening :" + e.ToString());
            }
            return myListener;
        }
    }
}
