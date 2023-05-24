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

        //int seat1_status = 0;
        //int seat2_status = 0;
        //int seat3_status = 0;
        //int seat4_status = 0;
        //public int Seat1_status { get { return seat1_status; } set { seat1_status = value; } }
        //public int Seat2_status { get { return seat2_status; } set { seat2_status = value; } }
        //public int Seat3_status { get { return seat3_status; } set { seat3_status = value; } }
        //public int Seat4_status { get { return seat4_status; } set { seat4_status = value; } }

        public void ArduinoConnect()
        {



        }// end of Arduino
    }




}










