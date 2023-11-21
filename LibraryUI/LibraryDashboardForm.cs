using Dapper;
using SeatMonitoringLibrary;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Timers;
using Timer = System.Timers.Timer;

namespace LibraryUI
{
    public partial class LibraryDashboardForm : Form
    {
        private SerialPort _serialPort;
        private SerialPort _serialPortId;
        public bool getData = false;
        // Create a timer object
        private Timer timer1 = new Timer();
        private Timer timer2 = new Timer();
        private Timer timer3 = new Timer();
        private Timer timer4 = new Timer();
        private Timer timer5 = new Timer();
        int index1 = 0;
        int index2 = 0;
        int index3 = 0;
        int index4 = 0;
        int incrementIndex = 0;
        // string id_port;
        // string seat_port;


        // ids

        int student_id1 = 0;
        int student_id2 = 0;
        int student_id3 = 0;
        int student_id4 = 0;
        int seat_number1 = 0;
        int seat_number2 = 0;
        int seat_number3 = 0;
        int seat_number4 = 0;
        string expiredAt1 = "";
        string expiredAt2 = "";
        string expiredAt3 = "";
        string expiredAt4 = "";
        string name1 = "";
        string name2 = "";
        string name3 = "";
        string name4 = "";

        /// <summary>
        /// get away time
        /// </summary>
        int timeState1 = 0;
        int timeState2 = 0;
        int timeState3 = 0;
        int timeState4 = 0;















        TimerModel timerModel = new TimerModel();
        // SeatListForm seatListForm = new SeatListForm();
        int seat1_timer = 0;
        int seat2_timer = 0;
        int seat3_timer = 0;
        int seat4_timer = 0;
        bool seatBool = true;

        public int Seat1_timer { get { return seat1_timer; } set { seat1_timer = value; } }
        public int Seat2_timer { get { return seat2_timer; } set { seat2_timer = value; } }
        public int Seat3_timer { get { return seat3_timer; } set { seat3_timer = value; } }
        public int Seat4_timer { get { return seat4_timer; } set { seat4_timer = value; } }
        // public int Seat5_timer { get { return seat5_timer; } set { seat5_timer = value; } }


        DatabaseAccessModel databaseAccessModel = new DatabaseAccessModel();
        StudentModel studentModel = new StudentModel();

        public LibraryDashboardForm()
        {
            InitializeComponent();
            displayData();
            ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();

            // Initialize the timer with a 5-second interval
            timer1 = new Timer(200);
            timer2 = new Timer(500);
            timer3 = new Timer(1500);
            timer4 = new Timer(2000);
            timer5 = new Timer(1000);


            // Attach an event handler for the timer's Elapsed event
            timer1.Elapsed += Timer1_Elapsed;
            timer2.Elapsed += Timer2_Elapsed;
            timer3.Elapsed += Timer3_Elapsed;
            timer4.Elapsed += Timer4_Elapsed;
            timer5.Elapsed += Timer5_Elapsed;


        }

        public LibraryDashboardForm(string Name)
        {
            InitializeComponent();
            //displayData();
            GetAllSeatTime();
            adminName.Text = Name;
            //availableSeatsLabel.Text = databaseAccessModel.GetAvailableSeat().ToString();

            // Initialize the timer with a 5-second interval
            timer1 = new Timer(200);
            timer2 = new Timer(500);
            timer3 = new Timer(500);
            timer4 = new Timer(500);
            timer5 = new Timer(1000);

            // Attach an event handler for the timer's Elapsed event
            timer1.Elapsed += Timer1_Elapsed;
            timer2.Elapsed += Timer2_Elapsed;
            timer3.Elapsed += Timer3_Elapsed;
            timer4.Elapsed += Timer4_Elapsed;
            timer5.Elapsed += Timer5_Elapsed;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;
            Label.CheckForIllegalCrossThreadCalls = false;
            ComboBox.CheckForIllegalCrossThreadCalls = false;

        }



        public void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {

            try
            {
                // Perform any necessary UI updates on the main UI thread
                Invoke(new Action(() =>
                {


                    KeepCheckingStatus();

                }));
            }catch (Exception ex)
            {

            }
        }


        int incrementSeat1Timer = 100;
        int incrementSeat2Timer = 100;
        int incrementSeat3Timer = 100;
        int incrementSeat4Timer = 100;

        int seatNumber1 = 1;
        int seatNumber2 = 2;
        int seatNumber3 = 3;
        int seatNumber4 = 4;


        int studId;
        bool is_charged = false;
        int ChargeStatus = 5;



        bool Istimer1zero = false;
        bool Istimer2zero = false;
        bool Istimer3zero = false;
        bool Istimer4zero = false;



        // seat status

        int seatStatus1 = 0;
        int seatStatus2 = 0;
        int seatStatus3 = 0;
        int seatStatus4 = 0;
        public async void KeepCheckingStatus()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seatStatus1", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@seatStatus2", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                s.Add("@seatStatus3", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                s.Add("@seatStatus4", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("spGetAll_seat_statusSEC", s, commandType: CommandType.StoredProcedure);

                seatStatus1 = s.Get<int>("@seatStatus1");
                seatStatus2 = s.Get<int>("@seatStatus2");
                seatStatus3 = s.Get<int>("@seatStatus3");
                seatStatus4 = s.Get<int>("@seatStatus4");














                if (seatStatus4 == 1)
                {
                    incrementSeat4Timer = 100;
                }



                if (seatStatus4 == 0 && s4 == 1)

                {


                    //new code
                    if (seatStatus4 == 0 && s4 == 0)
                    {
                        GetUserDetais4(4);
                        DeleteIdLeaves(studentModel.StudentId);
                        // Istimer4zero = false;
                    }


                    incrementSeat4Timer--;



                    if (incrementSeat4Timer <= 0)
                    {

                        GetUserDetais4(4);
                        DeleteId(studentModel.StudentId);
                        databaseAccessModel.GetSeatFromUser(studentModel.StudentId, studentModel.User_id);

                    }

                    if (incrementSeat4Timer-- > 0)
                    {


                        CountDown4(incrementSeat4Timer, seatNumber4);
                    }


                }//ends


                if (seatStatus3 == 1)
                {
                    incrementSeat3Timer = 100;
                }

                if (seatStatus3 == 0 && s3 == 1)
                {
                    //new code
                    if (seatStatus3 == 0 && s3 == 0)
                    {
                        GetUserDetais3(3);
                        DeleteIdLeaves(studentModel.StudentId);
                        // Istimer3zero = false;
                    }


                    incrementSeat3Timer--;
                    if (incrementSeat3Timer <= 0)
                    {



                        GetUserDetais3(3);
                        DeleteId(studentModel.StudentId);
                        databaseAccessModel.GetSeatFromUser(studentModel.StudentId, studentModel.User_id);






                    }

                    if (incrementSeat3Timer-- > 0)
                        CountDown3(incrementSeat3Timer, seatNumber3);
                }//end




                if (seatStatus2 == 1)
                {
                    incrementSeat2Timer = 100;
                }

                if (seatStatus2 == 0 && s2 == 1)
                {


                    //new code
                    if (seatStatus2 == 0 && s2 == 0)
                    {


                        GetUserDetais2(2);
                        DeleteIdLeaves(studentModel.StudentId);

                        //Istimer2zero = false;



                    }







                    incrementSeat2Timer--;

                    if (incrementSeat2Timer <= 0)
                    {






                        GetUserDetais2(2);
                        DeleteId(studentModel.StudentId);
                        databaseAccessModel.GetSeatFromUser(studentModel.StudentId, studentModel.User_id);




                    }
                    if (incrementSeat2Timer-- > 0)
                        CountDown2(incrementSeat2Timer, seatNumber2);

                }//ends




                if (seatStatus1 == 1)
                {
                    incrementSeat1Timer = 100;
                }

                if (seatStatus1 == 0 && s1 == 1)
                {
                    //new code
                    if (seatStatus1 == 0 && s1 == 0)
                    {

                        GetUserDetais1(1);
                        DeleteIdLeaves(studentModel.StudentId);
                        // Istimer1zero = false;
                    }

                    incrementSeat1Timer--;



                    if (incrementSeat1Timer <= 0)
                    {


                        GetUserDetais1(1);
                        DeleteId(studentModel.StudentId);
                        databaseAccessModel.GetSeatFromUser(studentModel.StudentId, studentModel.User_id);







                    }




                    if (incrementSeat1Timer-- > 0)
                    {
                        CountDown1(incrementSeat1Timer, seatNumber1);
                    }



                }; //ends


            }

        }




        async void GetUserDetais4(int Seat_id)
        {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@Seat_id", Seat_id);
                s.Add("@Name", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                s.Add("@Seat_number", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@Student_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spGetUserDetailstSEC", s, commandType: CommandType.StoredProcedure);

                seat_number4 = s.Get<int>("@Seat_number");

                try
                {


                    student_id4 = s.Get<int>("@Student_id");

                    name4 = s.Get<string>("@Name");



                }
                catch
                {




                }


                AddToTimeOut4(student_id4, name4, seat_number4);
                Retrieve(student_id4);

            }



        }































        async void GetUserDetais3(int Seat_id)
        {





            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@Seat_id", Seat_id);
                s.Add("@Name", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                s.Add("@Seat_number", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@Student_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spGetUserDetailstSEC", s, commandType: CommandType.StoredProcedure);


                try
                {


                    student_id3 = s.Get<int>("@Student_id");
                    seat_number3 = s.Get<int>("@Seat_number");
                    name3 = s.Get<string>("@Name");



                }
                catch
                {




                }





                AddToTimeOut3(student_id3, name3, seat_number3);
                Retrieve(student_id3);


            }



        }


        async void GetUserDetais2(int Seat_id)
        {





            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@Seat_id", Seat_id);
                s.Add("@Name", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                s.Add("@Seat_number", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@Student_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spGetUserDetailstSEC", s, commandType: CommandType.StoredProcedure);



                try
                {
                    student_id2 = s.Get<int>("@Student_id");
                    seat_number2 = s.Get<int>("@Seat_number");
                    name2 = s.Get<string>("@Name");
                }
                catch
                {




                }





                AddToTimeOut2(student_id2, name2, seat_number2);
                Retrieve(student_id2);

            }



        }


        async void GetUserDetais1(int Seat_id)
        {





            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@Seat_id", Seat_id);
                s.Add("@Name", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                s.Add("@Seat_number", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@Student_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spGetUserDetailstSEC", s, commandType: CommandType.StoredProcedure);



                try
                {


                    student_id1 = s.Get<int>("@Student_id");
                    seat_number1 = s.Get<int>("@Seat_number");
                    name1 = s.Get<string>("@Name");



                }
                catch
                {




                }





                AddToTimeOut1(student_id1, name1, seat_number1);
                Retrieve(student_id1);

            }



        }













































        async void AddToTimeOut1(int student_id, string Name, int seat_number)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@Student_id", student_id);
                s.Add("@Name", Name);
                s.Add("@Seat_number", seat_number);
                connection.Execute("spAddTimeOutSEC", s, commandType: CommandType.StoredProcedure);

            }

        }

        async void AddToTimeOut2(int student_id, string Name, int seat_number)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@Student_id", student_id);
                s.Add("@Name", Name);
                s.Add("@Seat_number", seat_number);
                connection.Execute("spAddTimeOutSEC", s, commandType: CommandType.StoredProcedure);

            }

        }


        async void AddToTimeOut3(int student_id, string Name, int seat_number)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@Student_id", student_id);
                s.Add("@Name", Name);
                s.Add("@Seat_number", seat_number);
                connection.Execute("spAddTimeOutSEC", s, commandType: CommandType.StoredProcedure);

            }

        }

        async void AddToTimeOut4(int student_id, string Name, int seat_number)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@Student_id", student_id);
                s.Add("@Name", Name);
                s.Add("@Seat_number", seat_number);
                connection.Execute("spAddTimeOutSEC", s, commandType: CommandType.StoredProcedure);

            }

        }



















        public async void ChangeStateToZero(int student_id, string user_id)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@student_id", student_id);
                s.Add("@user_id", user_id);
                connection.Execute("ChangeStateZeroSEC", s, commandType: CommandType.StoredProcedure);

            }

        }





        public async void DeleteId(int seat_number)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seat_number", seat_number);
                //s.Add("@time", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("GetTimeSEC", s, commandType: CommandType.StoredProcedure);



            }

        }



        public async void DeleteIdLeaves(int id)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@id", id);
                //s.Add("@time", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("leavesSEC", s, commandType: CommandType.StoredProcedure);



            }

        }



        async void Charge(int student_id, int cash)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@Student_id", student_id);
                s.Add("@cash", cash);

                connection.Execute("spCharge", s, commandType: CommandType.StoredProcedure);

            }
            ChangeChargeState(student_id);
        }


        async void Retrieve(int S_id)
        {
            int cash = 0;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();
                s.Add("@S_id", S_id);
                s.Add("@Cash", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@ChargeStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spRetrieve", s, commandType: CommandType.StoredProcedure);




                try
                {
                    cash = s.Get<int>("@Cash");
                    ChargeStatus = s.Get<int>("@ChargeStatus");

                }
                catch
                {

                }

            }
            // add to total
            if (ChargeStatus == 0)
            {
                Charge(S_id, cash);
            }


        }


        async void ChangeChargeState(int S_id)
        {
            int cash = 0;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();
                s.Add("@S_id", S_id);
                connection.Execute("spChangeChargeState", s, commandType: CommandType.StoredProcedure);




                try
                {


                }
                catch
                {

                }

            }



        }







































        public async void CountDown1(int countDown, int seatNumber)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@countDown", countDown);
                s.Add("@seatNumber", seatNumber);
                s.Add("@Student_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@ExpiredAt", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                connection.Execute("spCountDown1SEC", s, commandType: CommandType.StoredProcedure);

                student_id1 = s.Get<int>("@Student_id");
                expiredAt1 = s.Get<string>("@ExpiredAt");

            }

        }


        public async void TimeStamp1(int seatNumber)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();


                s.Add("@seat_number", seatNumber);
                connection.Execute("spTimeStamp1SEC", s, commandType: CommandType.StoredProcedure);



            }

        }

        public async void TimeStamp2(int seatNumber)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();


                s.Add("@seat_number", seatNumber);
                connection.Execute("spTimeStamp2SEC", s, commandType: CommandType.StoredProcedure);



            }

        }

        public async void TimeStamp3(int seatNumber)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();


                s.Add("@seat_number", seatNumber);
                connection.Execute("spTimeStamp3SEC", s, commandType: CommandType.StoredProcedure);



            }

        }

        public async void TimeStamp4(int seatNumber)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();


                s.Add("@seat_number", seatNumber);
                connection.Execute("spTimeStamp4SEC", s, commandType: CommandType.StoredProcedure);



            }

        }












        public async void CountDown2(int countDown, int seatNumber)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@countDown", countDown);
                s.Add("@seatNumber", seatNumber);
                s.Add("@Student_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@ExpiredAt", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                connection.Execute("spCountDown2SEC", s, commandType: CommandType.StoredProcedure);

                student_id2 = s.Get<int>("@Student_id");
                expiredAt2 = s.Get<string>("@ExpiredAt");

            }

        }


        public async void CountDown3(int countDown, int seatNumber)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@countDown", countDown);
                s.Add("@seatNumber", seatNumber);
                s.Add("@Student_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@ExpiredAt", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                connection.Execute("spCountDown3SEC", s, commandType: CommandType.StoredProcedure);

                student_id3 = s.Get<int>("@Student_id");
                expiredAt3 = s.Get<string>("@ExpiredAt");

            }

        }



        public async void CountDown4(int countDown, int seatNumber)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@countDown", countDown);
                s.Add("@seatNumber", seatNumber);
                s.Add("@Student_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@ExpiredAt", 0, dbType: DbType.String, direction: ParameterDirection.Output);

                connection.Execute("spCountDown4SEC", s, commandType: CommandType.StoredProcedure);

                student_id4 = s.Get<int>("@Student_id");
                expiredAt4 = s.Get<string>("@ExpiredAt");

            }

        }










































        int getSeatState = 0;
        int getLogin_State = 0;
        public async void GetStatus_andd_Id(int seatId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seatId", seatId);
                s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@login_status", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spGetSeatState_and_Login_states", s, commandType: CommandType.StoredProcedure);

                try
                {
                    getSeatState = s.Get<int>("@seatStatus");
                    getLogin_State = s.Get<int>("@login_status");

                }
                catch (Exception ex)
                {

                }


            }

        }














































        public void Timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            try { 
            Invoke(new Action(() =>
            {


                DeleteId(seatNumber1);
                DeleteId(seatNumber2);
                DeleteId(seatNumber3);
                DeleteId(seatNumber4);












            }));
        }catch (Exception ex) { 
            
            }
        }

        public void Timer3_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Invoke(new Action(() =>
                {

                }));
            }catch (Exception ex)
            {


            }
        }

        public void Timer4_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {

                // Perform any necessary UI updates on the main UI thread
                Invoke(new Action(() =>
                {

                }));
            }catch (Exception ex)
            {


            }
        }


        public void Timer5_Elapsed(object sender, ElapsedEventArgs e)
        {

            try { 
            Invoke(new Action(() =>
            {
                displayData();
                //InsertAllTime();
                availableSeatsLabel.Text = databaseAccessModel.GetAvailableSeat().ToString();
                seat_asigned.Text = databaseAccessModel.AsignedSeat.ToString();





            }));
        }
            catch (Exception ex)
            {


            }
        }



































        int j = 0;
        int i = 0;
        // table inset seat timer
        public async void InsertAllTime()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seat1_timer", Seat1_timer);
                s.Add("@seat2_timer", Seat2_timer);
                s.Add("@seat3_timer", Seat3_timer);
                s.Add("@seat4_timer", Seat4_timer);

                // s.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spInsertAllTimerSEC", s, commandType: CommandType.StoredProcedure);
                //id = s.Get<int>("@id");

            }

        }


        // table Get timers
        public async void GetAllSeatTime()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seat1_timer", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@seat2_timer", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@seat3_timer", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@seat4_timer", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("spGetAll_timerSEC", s, commandType: CommandType.StoredProcedure);
                try
                {

                    seat1_timer = s.Get<int>("@seat1_timer");
                    seat2_timer = s.Get<int>("@seat2_timer");
                    seat3_timer = s.Get<int>("@seat3_timer");
                    seat4_timer = s.Get<int>("@seat4_timer");
                }
                catch (Exception ex)
                {



                }



            }

        }
































        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }







        async void GetTimeState()
        {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();


                s.Add("@time1", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@time2", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@time3", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@time4", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spGetTimeStateSEC", s, commandType: CommandType.StoredProcedure);



                try
                {


                    timeState1 = s.Get<int>("time1");
                    timeState2 = s.Get<int>("time2");
                    timeState3 = s.Get<int>("time3");
                    timeState4 = s.Get<int>("time4");



                }
                catch
                {




                }




            }



        }



















        private void available_Click(object sender, EventArgs e)
        {
            GetTimeState();
            try
            {
                //SeatListForm seatListForm = new SeatListForm(s1, s2, s3, s4);
                SeatListForm seatListForm = new SeatListForm(timeState1, timeState2, timeState3, timeState4);
                seatListForm.Show();


            }
            catch (ObjectDisposedException e2)
            {
                // SeatListForm seatListForm = new SeatListForm(s1, s2, s3, s4);
                SeatListForm seatListForm = new SeatListForm(timeState1, timeState2, timeState3, timeState4);
                seatListForm.Show();
            }




        }

        private void counterDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void logout_Click(object sender, EventArgs e)
        {

            InsertAllTime();
            LoginForm1 loginForm = new LoginForm1();

            this.Hide();
            loginForm.Show();
        }


        async void displayData()
        {

            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                using (SqlCommand cmd = new SqlCommand("spStudents_GetAllSEC", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    DataTable dt = new DataTable();



                    try
                    {
                        SqlDataReader sqlDr = cmd.ExecuteReader();
                        dt.Load(sqlDr);
                        counterDataGrid.DataSource = dt;
                    }
                    catch (Exception esr)
                    {


                    }



                    connection.Close();


                }

            }

        }




        private void refreshButton_Click(object sender, EventArgs e)
        {



            databaseAccessModel.GetAvailableSeat();
            displayData();
            availableSeatsLabel.Text = databaseAccessModel.GetAvailableSeat().ToString();
        }






        // other code
        private void connectBT_Click(object sender, EventArgs e)
        {


            String[] Ports = SerialPort.GetPortNames();


            //id_port = "COM6";
            //seat_port = "COM5";




            //Thread.Sleep(10);
            //connectBT.Enabled = false;


        }

        private void outgoingTB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openPort_Click(object sender, EventArgs e)
        {

            _serialPort = new SerialPort();
            _serialPort.PortName = "COM15";
            _serialPort.BaudRate = 9600;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            // _serialPort.Open();




            _serialPortId = new SerialPort();
            _serialPortId.PortName = "COM16"; ;
            _serialPortId.BaudRate = 9600;
            _serialPortId.DataBits = 8;
            _serialPortId.StopBits = StopBits.One;
            _serialPortId.Parity = Parity.None;
            //_serialPort.Open();
            Thread.Sleep(50);

            Thread seatThread = new Thread(ReadSeatStatus);
            Thread seatThreadId = new Thread(ReadId);
            seatThread.Start();
            seatThreadId.Start();



            openPort.Enabled = false;

            Thread.Sleep(2000);
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();
            Thread.Sleep(1000);
            displayData();

        }



        private void display_Click(object sender, EventArgs e)
        {

        }




        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {


        }

        private void displayseat2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void enter_Click(object sender, EventArgs e)
        {
            // DatabaseAccessModel databaseAccessModel = new DatabaseAccessModel();

            displayData();
            availableSeatsLabel.Text = databaseAccessModel.GetAvailableSeat().ToString();
            // databaseAccessModel.UpdateSeatsStatusTo_One(19143648);

            displayData();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {


        }


        int s1;
        int s2;
        int s3;
        int s4;




        void ReadId()
        {
            // string globalVa = "5,5,5,5";
            string globalVaId = "id";

            while (true)
            {


                try
                {
                    StudentModel studentModel = new StudentModel();

                    if (!_serialPortId.IsOpen)
                    {
                        a.Text = "id";
                        _serialPortId = new SerialPort();
                        _serialPortId.PortName = "COM16";
                        _serialPortId.BaudRate = 9600;
                        _serialPort.DataBits = 8;
                        _serialPortId.StopBits = StopBits.One;
                        _serialPortId.Parity = Parity.None;
                        _serialPortId.Open();


                        try
                        {

                            globalVaId = _serialPortId.ReadLine();
                            // textBoxId.Text = globalVaId;
                            string id = globalVaId.Trim();

                            databaseAccessModel.VerifyStudent(id);
                            Thread.Sleep(1000);
                            // textBoxId.Text = "";
                            globalVaId = "";
                            seatBool = true;
                        }

                        catch (Exception ex)
                        {
                            globalVaId = _serialPortId.ReadLine();
                            // textBoxId.Text = globalVaId;
                            string id = globalVaId.Trim();

                            databaseAccessModel.VerifyStudent(id);
                            Thread.Sleep(1000);
                            // textBoxId.Text = "";
                            globalVaId = "";
                            _serialPortId.Close();

                            globalVaId = "";
                            seatBool = true;

                        }


                        _serialPortId.Close();


                    }
                    else
                    {
                        // string globalVaId = "";
                        globalVaId = _serialPortId.ReadLine();
                        // textBoxId.Text = globalVaId;
                        string id = globalVaId.Trim();
                        databaseAccessModel.VerifyStudent(id);
                        Thread.Sleep(500);
                        //textBoxId.Text = "";
                        globalVaId = "";

                        _serialPortId.Close();



                    }

                }


                catch (Exception seatThead)
                {

                    StudentModel studentModel = new StudentModel();
                    int checkSeat_status = 0;
                    //string global;
                    _serialPortId = new SerialPort();
                    _serialPortId.PortName = "COM16"; ;
                    _serialPortId.BaudRate = 9600;
                    _serialPortId.DataBits = 8;
                    _serialPortId.StopBits = StopBits.One;
                    _serialPortId.Parity = Parity.None;
                    _serialPortId.Open();
                    globalVaId = _serialPortId.ReadLine();
                    // textBoxId.Text = globalVaId;
                    string id = globalVaId.Trim();
                    databaseAccessModel.VerifyStudent(id);
                    // textBoxId.Text = "";
                    Thread.Sleep(1000);
                    _serialPortId.Close();

                }




            }



        }



        public void ReadSeatStatus()
        {

            // DatabaseAccessModel databaseAccessModel = new DatabaseAccessModel();
            string globalVa = "";
            // string globalVaId = "id";

            ArduinoConnectModel connectModel = new ArduinoConnectModel();
            while (true)
            {

                try
                {


                    if (!_serialPort.IsOpen)
                    {
                        _serialPort = new SerialPort();
                        _serialPort.PortName = "COM15";
                        _serialPort.BaudRate = 9600;
                        _serialPort.DataBits = 8;
                        _serialPort.StopBits = StopBits.One;
                        _serialPort.Parity = Parity.None;
                        _serialPort.Open();


                        char[] separator = { ',' };

                        try
                        {
                            globalVa = _serialPort.ReadLine();
                            Thread.Sleep(100);
                            globalVa = _serialPort.ReadLine();
                            string[] myArray = globalVa.Split(separator);
                            databaseAccessModel.Seat1_status = int.Parse(myArray[0]);
                            databaseAccessModel.Seat2_status = int.Parse(myArray[1]);
                            databaseAccessModel.Seat3_status = int.Parse(myArray[2]);
                            databaseAccessModel.Seat4_status = int.Parse(myArray[3]);

                            s1 = int.Parse(myArray[0]);
                            s2 = int.Parse(myArray[1]);
                            s3 = int.Parse(myArray[2]);
                            s4 = int.Parse(myArray[3]);

                            seatBool = true;

                            a.Text = globalVa;

                            seatData.Text = globalVa;
                            databaseAccessModel.InsertSeatStatus();
                            Thread.Sleep(100);
                            seatData.Text = "";

                        }
                        catch (Exception ex)
                        {
                            databaseAccessModel.InsertSeatStatus();
                            _serialPort.Close();
                            seatBool = true;
                        }

                        Thread.Sleep(100);
                        _serialPort.Close();


                    }
                    else
                    {
                        char[] separator = { ',' };

                        globalVa = _serialPort.ReadLine();
                        string[] myArray = globalVa.Split(separator);
                        databaseAccessModel.Seat1_status = int.Parse(myArray[0]);
                        databaseAccessModel.Seat2_status = int.Parse(myArray[1]);
                        databaseAccessModel.Seat3_status = int.Parse(myArray[2]);
                        databaseAccessModel.Seat4_status = int.Parse(myArray[3]);

                        s1 = int.Parse(myArray[0]);
                        s2 = int.Parse(myArray[1]);
                        s3 = int.Parse(myArray[2]);
                        s4 = int.Parse(myArray[3]);
                        seatBool = true;

                        seatData.Text = globalVa;
                        Thread.Sleep(100);
                        seatData.Text = myArray[3];
                        databaseAccessModel.InsertSeatStatus();
                        globalVa = _serialPort.ReadLine();
                        seatData.Text = globalVa;
                        Thread.Sleep(100);
                        seatData.Text = "";

                        if (!timer1.Enabled)
                        {
                            timer1.Start();
                        }
                        if (!timer2.Enabled)
                        {
                            timer2.Start();
                        }
                        if (!timer3.Enabled)
                        {
                            timer3.Start();
                        }
                        if (!timer4.Enabled)
                        {
                            timer4.Start();
                        }



                        _serialPort.Close();



                    }

                }


                catch (Exception seatThead)
                {
                    _serialPort = new SerialPort();
                    _serialPort.PortName = "COM15";
                    _serialPort.BaudRate = 9600;
                    _serialPort.DataBits = 8;
                    _serialPort.StopBits = StopBits.One;
                    _serialPort.Parity = Parity.None;
                    _serialPort.Open();
                    globalVa = _serialPort.ReadLine();
                    seatData.Text = globalVa;
                    databaseAccessModel.InsertSeatStatus();
                    Thread.Sleep(100);
                    seatData.Text = "";
                    seatBool = true;
                    _serialPort.Close();

                }





                //// second port






            }// endof while




        }// end of read thread

        private void seatData_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {


        }

        private void reasignedbt_Click(object sender, EventArgs e)
        {

        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(seachTextBox.Text);
            Search(id);

        }

        int RetrievedSeat = 0;
        public async void Search(int id)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@S_id", id);
                s.Add("@seatNumber", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("spSearch", s, commandType: CommandType.StoredProcedure);



                try
                {
                    RetrievedSeat = s.Get<int>("@seatNumber");
                    seat_asigned.Text = RetrievedSeat.ToString();
                }
                catch (Exception esr)
                {


                }







            }

        }

















        private void seachTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void adminName_Click(object sender, EventArgs e)
        {
        }

        private void help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void availableSeatsLabel_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void settings_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            ResetStatus();
        }

        public async void ResetStatus()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();



                connection.Execute("spIResetStatus", s, commandType: CommandType.StoredProcedure);


            }

        }
















        private void timeOutButton_Click(object sender, EventArgs e)
        {

            ReasignedSeats reasignedSeats = new ReasignedSeats();


            reasignedSeats.Show();


        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();


        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void a_Click(object sender, EventArgs e)
        {

        }
    }

}

