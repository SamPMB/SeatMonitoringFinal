using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SeatMonitoringLibrary
{
    public class ArduinoConnectModel
    {

        //   get seat data
        int seatsAvailable;
        int seat1;
        int seat2;
        int seat3;
        int seat4;
        public int Seat1 { get { return seat1; } set { seat1 = value; } }
        public int Seat2 { get { return seat2; } set { seat2 = value; } }
        public int Seat3 { get { return seat3; } set { seat3 = value; } }
        public int Seat4 { get { return seat4; } set { seat4 = value; } }
        public int SeatsAvailable { get { return seatsAvailable; } set { seatsAvailable = value; } }

        int seat1_status = 0;
        int seat2_status = 0;
        int seat3_status = 0;
        int seat4_status = 0;
        public int Seat1_status { get { return seat1_status; } set { seat1_status = value; } }
        public int Seat2_status { get { return seat2_status; } set { seat2_status = value; } }
        public int Seat3_status { get { return seat3_status; } set { seat3_status = value; } }
        public int Seat4_status { get { return seat4_status; } set { seat4_status = value; } }

        public void ArduinoConnect()
        {


            // create a TCP listener
            TcpListener listener = new TcpListener(IPAddress.Any, 1000);

            // start listening for incoming connections
            listener.Start();
            Console.WriteLine("Waiting for connection...");

            // accept an incoming connection
            //TcpClient client = listener.AcceptTcpClient();


            // get the network stream for the client
            // NetworkStream stream = client.GetStream();
            //Thread.Sleep(500);
            // continuously read data from the client
            while (true)
            {
                listener.Start();
                Console.WriteLine("Connected");
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                Thread.Sleep(500);
                byte[] data = new byte[1024];
                //int bytesRead = stream.Read(data, 0, data.Length);



                // Assume that 'stream' is a Stream object containing the byte data
                // byte[] buffer = new byte[4096]; // create a buffer to read the stream
                StringBuilder sb = new StringBuilder(); // create a StringBuilder to build the string

                // Read the byte data from the stream and append it to the StringBuilder
                int bytesRead;
                while ((bytesRead = stream.Read(data, 0, data.Length)) > 0)
                {
                    sb.Append(Encoding.UTF8.GetString(data, 0, bytesRead));

                    //Console.WriteLine(sb.ToString());
                }

                // Split the resulting string into an array of strings
                string[] stringArray = sb.ToString().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                int cv1 = 5;
                int cv2 = 5;
                int cv3 = 5;
                int cv4 = 5;
                string cv5 = "";



                if (sb.Length > 4)
                {

                    cv1 = int.Parse(stringArray[0].Substring(0, 1));
                    cv2 = int.Parse(stringArray[0].Substring(1, 1));
                    cv3 = int.Parse(stringArray[0].Substring(2, 1));
                    cv4 = int.Parse(stringArray[0].Substring(3, 1));
                    cv5 = stringArray[0].Substring(8, 9);

                    Console.WriteLine();
                    Console.WriteLine(cv5);
                    Console.WriteLine();
                }
                else
                {
                    try
                    {

                        cv1 = int.Parse(stringArray[0].Substring(0, 1));
                        cv2 = int.Parse(stringArray[0].Substring(1, 1));
                        cv3 = int.Parse(stringArray[0].Substring(2, 1));
                        cv4 = int.Parse(stringArray[0].Substring(3, 1));

                    }
                    catch (Exception exep)
                    {


                    }



                    Console.WriteLine(cv1);
                    Console.WriteLine();
                    Console.WriteLine(cv2);
                    Console.WriteLine();
                    Console.WriteLine(cv3);
                    Console.WriteLine();
                    Console.WriteLine(cv4);

                }

                //Thread.Sleep(5000);


            }

        }// end of Arduino
    }




}










