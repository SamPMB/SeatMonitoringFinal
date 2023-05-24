using Dapper;
using System.Data;

namespace SeatMonitoringLibrary
{
    public class DatabaseAccessModel
    {

        Thread[] ThreadArray = new Thread[3];

        int seatTime = 0;
        int seatStatus = 0;
        public int SeatTime { get { return seatTime; } set { seatTime = value; } }
        public int SeatStatus { get { return seatStatus; } set { seatStatus = value; } }

        int awayTime1 = 60;
        int specSeatStatus1 = 0;
        public int AwayTime1 { get { return awayTime1; } set { awayTime1 = value; } }
        public int SpecSeatStatus1 { get { return specSeatStatus1; } set { specSeatStatus1 = value; } }

        int awayTime2 = 60;
        int specSeatStatus2 = 0;
        public int AwayTime2 { get { return awayTime2; } set { awayTime2 = value; } }
        public int SpecSeatStatus2 { get { return specSeatStatus2; } set { specSeatStatus2 = value; } }

        int awayTime3 = 60;
        int specSeatStatus3 = 0;
        public int AwayTime3 { get { return awayTime3; } set { awayTime3 = value; } }
        public int SpecSeatStatus3 { get { return specSeatStatus3; } set { specSeatStatus3 = value; } }

        int awayTime4 = 60;
        int specSeatStatus4 = 0;
        public int AwayTime4 { get { return awayTime4; } set { awayTime4 = value; } }
        public int SpecSeatStatus4 { get { return specSeatStatus4; } set { specSeatStatus4 = value; } }



        int checkSeatState = 0;
        public int CheckSeatState { get { return checkSeatState; } set { checkSeatState = value; } }




        int seat1_status = 0;
        int seat2_status =0;
        int seat3_status = 0;
        int seat4_status = 0;
        public int Seat1_status { get { return seat1_status; } set { seat1_status = value; } }
        public int Seat2_status { get { return seat2_status; } set { seat2_status = value; } }
        public int Seat3_status { get { return seat3_status; } set { seat3_status = value; } }
        public int Seat4_status { get { return seat4_status; } set { seat4_status = value; } }



        int stId = 0;
        public async void VerifyStudent(string userId)
        {

            //StudentModel studentModel = new StudentModel();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {

                var s = new DynamicParameters();
                s.Add("@userId", userId);
                s.Add("@firstName", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                s.Add("@year", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@studentId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spValidateLogin_userId", s, commandType: CommandType.StoredProcedure);
                studentModel.First_Name = s.Get<string>("@firstName");
                studentModel.Year = s.Get<int>("@year");
                stId = s.Get<int>("@studentId");
                studentModel.StudentId = stId;

            }


            GetFreeSeat();
        }

        public async void GetFreeSeat()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seatId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spGetFreeSeat", s, commandType: CommandType.StoredProcedure);

                try
                {
                    studentModel.Seat = s.Get<int>("@seatId");
                }
                catch (Exception dbex)
                {
                  
                }

            }


               LogingSeatStatus(studentModel.StudentId);

            if (isLoggedIn(studentModel.StudentId) && CheckSeatState ==1 )
            {
                checkSeatState = 0;
                LoginSeatStatusUpdateTo_zero(studentModel.StudentId);
                return;

            }else

            if (isLoggedIn(studentModel.StudentId) && checkSeatState == 0)
            {
                //CheckSeatState = 1;
                LoginSeatStatusUpdateTo_one(studentModel.StudentId);

                //updateSeats(studentModel.StudentId);
                //  studentModel.Seat = 0;


            }
            else
            if (isLoggedIn(studentModel.StudentId) == false && checkSeatState == 1)
            {

                updateSeats(studentModel.StudentId);
                LoginSeatStatusUpdateTo_zero(studentModel.StudentId);
                studentModel.Seat = 0;


            }
            else
            {

                studentModel.Seat = 1;
                AsignSeat(studentModel.Seat, studentModel.First_Name, studentModel.Year, studentModel.StudentId);

            }


        }

        bool isLoggedIn(int studentId)
        {



            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@StudentId", studentId);
                s.Add("@isLoggedIn", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spIsLoggedIn", s, commandType: CommandType.StoredProcedure);


                int rst = 0;


                try
                {


                    rst = s.Get<int>("@isLoggedIn");


                }
                catch (Exception ex)
                {

                    return false;
                }





            }


            return true;
        }

        public async void updateSeats(int studentId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@StudentId", studentId);
                connection.Execute("dbo.spUpdateSeats", s, commandType: CommandType.StoredProcedure);


            }

        }


        public async void updateSeats_One(int studentId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@StudentId", studentId);
                connection.Execute("dbo.spUpdateSeats_To_One", s, commandType: CommandType.StoredProcedure);


            }

        }
























        public async void AsignSeat(int seatId, string name, int yearOfStudy, int studentId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {

                var s = new DynamicParameters();

                s.Add("@cardId", cardId);
                s.Add("@seatId", seatId);
                s.Add("@name", name);
                s.Add("@yearOfStudy", yearOfStudy);
                s.Add("@studentId", studentId);
                // s.Add("@card", card);

                // s.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spAsignSeats", s, commandType: CommandType.StoredProcedure);
                //id = s.Get<int>("@id");

            }
            updateSeats_One(studentModel.StudentId);
            // added
            LoginSeatStatusUpdateTo_one(studentModel.StudentId);

        }









































































        //  get seat status
        public async void LogingSeatStatus(int studentId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@StudentId", studentId);
                s.Add("@loggedStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spLoginStatus", s, commandType: CommandType.StoredProcedure);

                checkSeatState = s.Get<int>("@loggedStatus");
            }

        }


        //  update login state
        public async void LoginSeatStatusUpdateTo_one(int studentId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@studentId", studentId);
                connection.Execute("dbo.loggedStatusUpdate_to_One", s, commandType: CommandType.StoredProcedure);

            }

        }


        //  update login state
        public async void LoginSeatStatusUpdateTo_zero(int studentId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@studentId", studentId);
                connection.Execute("dbo.loggedStatusUpdate_to_zero", s, commandType: CommandType.StoredProcedure);

            }

        }



































        // asign seat
      


        int cardId;
        StudentModel studentModel = new StudentModel();

        // table inset status
        public async void InsertSeatStatus()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                // insert into the seat table
                var s = new DynamicParameters();

                s.Add("@seat1_status", Seat1_status);
                s.Add("@seat2_status", Seat2_status);
                s.Add("@seat3_status", Seat3_status);
                s.Add("@seat4_status", Seat4_status);
                s.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spSeatStatus_Insert", s, commandType: CommandType.StoredProcedure);
            }

        }





























        public int GetSeat_status(int studentId)
        {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@StudentId", studentId);
                s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@seatTime", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spGet_seatStatus", s, commandType: CommandType.StoredProcedure);



                seatStatus = s.Get<int>("@seatStatus");
                SeatTime = s.Get<int>("@seatTime");


            }


            return SeatStatus;
        }

        public async void Get_specific_Seat1_status(int seatId)
        {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seatId", seatId);
                s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@awayTime", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spGet_SpecificSeatStatus1", s, commandType: CommandType.StoredProcedure);
                SpecSeatStatus1 = s.Get<int>("@seatStatus");
                AwayTime1 = s.Get<int>("@awayTime");


            }



        }


        public async void Get_specific_Seat2_status(int seatId)
        {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seatId", seatId);
                s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@awayTime", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spGet_SpecificSeatStatus2", s, commandType: CommandType.StoredProcedure);
                SpecSeatStatus2 = s.Get<int>("@seatStatus");
                AwayTime2 = s.Get<int>("@awayTime");


            }



        }

        public async void Get_specific_Seat3_status(int seatId)
        {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seatId", seatId);
                s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@awayTime", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spGet_SpecificSeatStatus3", s, commandType: CommandType.StoredProcedure);
                SpecSeatStatus3 = s.Get<int>("@seatStatus");
                AwayTime3 = s.Get<int>("@awayTime");


            }



        }

        public async void Get_specific_Seat4_status(int seatId)
        {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seatId", seatId);
                s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@awayTime", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spGet_SpecificSeatStatus4", s, commandType: CommandType.StoredProcedure);
                SpecSeatStatus4 = s.Get<int>("@seatStatus");
                AwayTime4 = s.Get<int>("@awayTime");


            }



        }



































        public bool TimeOut(int seatId)
        {
            int x = 0;
            //StudentModel studentModel = new StudentModel();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {

                var s = new DynamicParameters();
                s.Add("@seatId", seatId);
                s.Add("@seatState", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                connection.Execute("dbo.spSeatState", s, commandType: CommandType.StoredProcedure);

                // studentModel.SeatState = s.Get<int>("@seatState");
                x = s.Get<int>("@seatState");
                if (x == 0)
                    return false;

            }


            return true; //studentModel.SeatState;
        }









        public async void GetStudentId(int card)
        {

            cardId = card;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {

                var s = new DynamicParameters();
                s.Add("@cardId", card);
                s.Add("@firstName", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                s.Add("@year", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@studentId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spValidateLogin_Card", s, commandType: CommandType.StoredProcedure);
                studentModel.First_Name = s.Get<string>("@firstName");

                studentModel.Year = s.Get<int>("@year");
                studentModel.StudentId = s.Get<int>("@studentId");

            }

            GetFreeSeat();




        }



        // Available Seats
        public int GetAvailableSeat()
        {
            ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                // insert into the seat table
                var s = new DynamicParameters();


                s.Add("@seatsAvailable", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spSeatCount", s, commandType: CommandType.StoredProcedure);
                arduinoConnectModel.SeatsAvailable = s.Get<int>("@seatsAvailable");

            }
            return arduinoConnectModel.SeatsAvailable;

        }































        public async void updateSeatState1(int state)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@state", state);
                connection.Execute("dbo.spUpdateSeatState1", s, commandType: CommandType.StoredProcedure);


            }

        }

        public async void updateSeatState2(int state)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@state", state);
                connection.Execute("dbo.spUpdateSeatState2", s, commandType: CommandType.StoredProcedure);


            }

        }

        public async void updateSeatState3(int state)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@state", state);
                connection.Execute("dbo.spUpdateSeatState3", s, commandType: CommandType.StoredProcedure);


            }

        }

        public async void updateSeatState4(int state)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@state", state);
                connection.Execute("dbo.spUpdateSeatState4", s, commandType: CommandType.StoredProcedure);


            }

        }






    }
}
