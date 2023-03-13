using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using System.Data;

namespace SeatMonitoringLibrary
{
    public class ArduinoConnectModel
    {
 
         StaffModel staff = new StaffModel();
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

        int seat1_status;
        int seat2_status;
        int seat3_status;
        int seat4_status;
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
                }

                // Split the resulting string into an array of strings
                string[] stringArray = sb.ToString().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);


                seat1_status = int.Parse(stringArray[0].Substring(0, 1));

                seat2_status = int.Parse(stringArray[0].Substring(1, 1));

                seat3_status   =int.Parse(stringArray[0].Substring(2, 1));

                seat4_status = int.Parse(stringArray[0].Substring(3, 1));

                InsertSeatStatus();
                GetAvailableSeat();
            }// end of Arduino
        }



         // table inset status
        public void InsertSeatStatus()
        {
           
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                // insert into the seat table
                var s = new DynamicParameters();
             
                s.Add("@seat1_status", seat1_status);
                s.Add("@seat2_status", seat2_status);
                s.Add("@seat3_status", seat3_status);
                s.Add("@seat4_status", seat4_status);

                s.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spSeatStatus_Insert", s, commandType: CommandType.StoredProcedure);
                //id = s.Get<int>("@id");

            }

        }








        // Available Seats
        public int GetAvailableSeat()
        {    

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                // insert into the seat table
                var s = new DynamicParameters();

            
                s.Add("@seatsAvailable", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spSeatCount", s, commandType: CommandType.StoredProcedure);
                seatsAvailable = s.Get<int>("@seatsAvailable");
                
            }
             return seatsAvailable;
            
        }







    }





}


    

