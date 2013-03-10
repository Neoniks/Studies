using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using WebSerwer.Model;

namespace WebSerwer
{
    class Program
    {

        private static int port = 10500;
        public static TcpListener myListener;
        public static StartClass _start;
        public static ListenClass _listen = new ListenClass();

        public Program()
        {
            try
            {
                
                myListener = new TcpListener(port);
                myListener.Start();
                Console.WriteLine("Web Server Running... Press ^C to Stop...");

                
                Thread th = new Thread(new ThreadStart(StartListen));
                th.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine("An Exception Occurred while Listening :"
                                   + e.ToString());
            }
        }

        public static void Main()
        {
            Program MWS = new Program();
        }


        public TcpListener Start(int port)
        {
            try
            {

                myListener.Start();
                Console.WriteLine("Web Server Running... Press ^C to Stop...");

                Thread th = new Thread(new ThreadStart(StartListen));
                th.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("An Exception Occurred while Listening :" + e.ToString());
            }
            return myListener;
        }

        public void StartListen()
        {
            SenderClass _sender = new SenderClass();
            int iStartPos = 0;
            String sRequest;
            String sRequestedFile;
            String sErrorMessage;
            String sLocalDir;
            String sMyWebServerRoot = "E:\\Lab02\\";
            String sPhysicalFilePath = "";
            String sFormattedMessage = "";
            String sResponse = "";



            while (true)
            {
                //Accept a new connection
                Socket mySocket = myListener.AcceptSocket();
                String sMimeType = @"text/html";

                if (mySocket.Connected)
                {
                    Console.WriteLine("\nClient Connected!!\n==================\nCLient IP {0}\n",
                        mySocket.RemoteEndPoint);

                    Byte[] bReceive = new Byte[1024];
                    int i = mySocket.Receive(bReceive, bReceive.Length, 0);
                    string sBuffer = Encoding.ASCII.GetString(bReceive);

                    if (sBuffer.Substring(0, 3) != "GET")
                    {
                        Console.WriteLine("Only Get Method is supported..");
                    }
                    else
                    {
                        iStartPos = sBuffer.IndexOf("HTTP", 1);
                        string sHttpVersion = sBuffer.Substring(iStartPos, 8);

                        sRequest = sBuffer.Substring(0, iStartPos - 1);

                        iStartPos = sRequest.LastIndexOf("/") + 1;
                        sRequestedFile = sRequest.Substring(iStartPos);

                        sLocalDir = sMyWebServerRoot;

                        if (sLocalDir.Length == 0)
                        {
                            sErrorMessage = "<H2>Error!! Requested Directory does not exists</H2><Br>";
                            _sender.SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", ref mySocket);
                            _sender.SendToBrowser(sErrorMessage, ref mySocket);
                            mySocket.Close();
                            continue;
                        }
                        if (sRequestedFile.Length == 0)
                        {
                            sRequestedFile = "index.html";
                        }

                        sPhysicalFilePath = sLocalDir + sRequestedFile;


                        if (File.Exists(sPhysicalFilePath) == false)
                        {
                            sErrorMessage = "<H2>404 Error! File Does Not Exists...</H2>";
                            _sender.SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", ref mySocket);
                            _sender.SendToBrowser(sErrorMessage, ref mySocket);

                            Console.WriteLine(sFormattedMessage);
                        }

                        else
                        {
                            int iTotBytes = 0;

                            sResponse = "";

                            FileStream fs = new FileStream(sPhysicalFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                            BinaryReader reader = new BinaryReader(fs);
                            byte[] bytes = new byte[fs.Length];
                            int read;
                            while ((read = reader.Read(bytes, 0, bytes.Length)) != 0)
                            {
                                sResponse = sResponse + Encoding.ASCII.GetString(bytes, 0, read);
                                iTotBytes = iTotBytes + read;
                            }
                            reader.Close();
                            fs.Close();

                            _sender.SendHeader(sHttpVersion, sMimeType, iTotBytes, " 200 OK", ref mySocket);
                            _sender.SendToBrowser(bytes, ref mySocket);
                        }
                    }
                    mySocket.Close();
                }
            }
        }

    }
}
