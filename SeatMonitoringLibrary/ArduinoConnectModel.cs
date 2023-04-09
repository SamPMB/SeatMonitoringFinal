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


            // continuously read data from the client
            while (true)
            {
                listener.Start();

                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                Thread.Sleep(200);
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
                }

                // Split the resulting string into an array of strings
                string[] stringArray = sb.ToString().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);


                seat1_status = int.Parse(stringArray[0].Substring(0, 1));

                seat2_status = int.Parse(stringArray[0].Substring(1, 1));

                seat3_status = int.Parse(stringArray[0].Substring(2, 1));

                seat4_status = int.Parse(stringArray[0].Substring(3, 1));

                string card = stringArray[0].Substring(3, 1);

                DatabaseAccessModel databaseAccess = new DatabaseAccessModel();
                //SecurityModel securityModel = new SecurityModel();
                //databaseAccess.InsertSeatStatus();
                //databaseAccess.GetAvailableSeat();
                //databaseAccess.VerifyStudentId("19143648");

            }
            // 
        }// end of Arduino
    }




}










