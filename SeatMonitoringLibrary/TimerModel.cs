

namespace SeatMonitoringLibrary
{

    public class TimerModel
    {

        ArduinoConnectModel arduino = new ArduinoConnectModel();


        long seat1_Timer;
        long seat2_Timer;
        long seat3_Timer;
        long seat4_Timer;
        public long Seat1_Timer { get { return seat1_Timer; } set { seat1_Timer = value; } }
        public long Seat2_Timer { get { return seat2_Timer; } set { seat2_Timer = value; } }
        public long Seat3_Timer { get { return seat3_Timer; } set { seat3_Timer = value; } }
        public long Seat4_Timer { get { return seat4_Timer; } set { seat4_Timer = value; } }

        public void StartTimer()
        {

            if (arduino.Seat1 == 1)
            {
                seat1_Timer = seat1_Timer + 1;
            }
            else
            {

            }
            if (arduino.Seat2 == 1)
            {

            }
            else
            {

            }

            if (arduino.Seat3 == 1)
            {

            }
            else
            {

            }
            if (arduino.Seat4 == 1)
            {

            }
            else
            {

            }






        }




    }

}
