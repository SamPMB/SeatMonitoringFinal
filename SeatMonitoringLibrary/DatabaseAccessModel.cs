using Dapper;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Timers;
using System.Xml.Linq;
using Timer = System.Timers.Timer;

namespace SeatMonitoringLibrary
{
    public class DatabaseAccessModel
    {

        int asignedSeat = 0;
        public  int AsignedSeat { get { return asignedSeat; } set { asignedSeat = value; } }


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


        bool text;

        int seat1_status = 0;
        int seat2_status =0;
        int seat3_status = 0;
        int seat4_status = 0;
        public int Seat1_status { get { return seat1_status; } set { seat1_status = value; } }
        public int Seat2_status { get { return seat2_status; } set { seat2_status = value; } }
        public int Seat3_status { get { return seat3_status; } set { seat3_status = value; } }
        public int Seat4_status { get { return seat4_status; } set { seat4_status = value; } }


        public bool TextsO { get { return text; } set { text = value; } }


        int student_id = 0;
        int year_of_study = 0;
        string user_id = "";
        string first_name ="";
        string last_name = "";
        bool isIdExist = true;
        public async void VerifyStudent(string userId)
        {

            //StudentModel studentModel = new StudentModel();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {

                var s = new DynamicParameters();
                s.Add("@userId", userId);
                s.Add("@firstName", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                s.Add("@lastName", 0, dbType: DbType.String, direction: ParameterDirection.Output);
                s.Add("@year", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@studentId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spValidateLogin_userIdSEC", s, commandType: CommandType.StoredProcedure);

                

               
                    studentModel.First_Name = s.Get<string>("@firstName");
                    studentModel.Last_Name = s.Get<string>("@lastName");
                    first_name = s.Get<string>("@firstName");
                    last_name = s.Get<string>("@lastName");
                    studentModel.Year = s.Get<int>("@year");
                    student_id = s.Get<int>("@studentId");
                    studentModel.StudentId = student_id;
                    studentModel.User_id = user_id;
                    user_id = user_id;

        
            }

            CheckIfIdExit(student_id);
            GetSeatState(student_id, user_id);
            CheckLoginStatus(student_id, user_id);


            GetFreeSeat();
          

        }
        bool yoo = false;

        int freeSeatId = 0;
        public async void GetFreeSeat()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();
                
                s.Add("@seatId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spGetFreeSeatSEC", s, commandType: CommandType.StoredProcedure);

                try
                {
                    studentModel.SeatId = s.Get<int>("@seatId");
                    freeSeatId = s.Get<int>("@seatId");

                   

                }
                catch (Exception dbex)
                {
                  
                }


                

            }

            CheckIfIdExit(student_id);
            GetSeatState(student_id,user_id);
            CheckLoginStatus(student_id, user_id);
            Thread.Sleep(1000);
            
            if (seatState == 1 && isLoggedIn == true)
            {
                LoginSeatStatusUpdateTo_zero(student_id, user_id);

                
            }
            else
           if (seatState == 1 && isLoggedIn == false)
            {
                
                LoginSeatStatusUpdateTo_one(student_id, user_id);
                

            }
            else if(seatState == 0 && isLoggedIn == true)
            {
                GetSeatFromUser(student_id, user_id);

               
            }

             




            if (isIdExist == false)
            {
                
               
                    AsignSeat(freeSeatId, first_name, last_name, year_of_study, student_id, user_id,100);

                   AsignedSeat = freeSeatId;
            }
           


        }





        private async void DeleteId(int student_id)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@student_id", student_id);
                connection.Execute("DeleteIdSEC", s, commandType: CommandType.StoredProcedure);

            }

        }
      




















        public async void AsignSeat(int freeSeat_id, string first_name,string last_name, int year_of_study, int student_id, string user_id, int awayTime)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {

                var s = new DynamicParameters();

                
                s.Add("@freeSeat_id", freeSeat_id);
                s.Add("@awayTime", awayTime);
                s.Add("@first_name", first_name);
                s.Add("@last_name", last_name);
                s.Add("@user_id", user_id);
                s.Add("@year_of_study", year_of_study);
                s.Add("@student_id", student_id);
                connection.Execute("spAsignSeatsSEC", s, commandType: CommandType.StoredProcedure);


            }
        }
       // bool isIdExist = false;
        public async void CheckIfIdExit(int student_id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {

                var s = new DynamicParameters();

                s.Add("@studentId", student_id);
                s.Add("@student_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spIsIdExistSEC", s, commandType: CommandType.StoredProcedure);
                

                try
                {
                    int id = s.Get<int>("@student_id");

                    if (id == student_id)
                    {

                        isIdExist = true;
                    }
                    else
                    {
                        isIdExist = false;

                    }
                }
                catch (Exception ex)
                {
                    isIdExist = false;
                   

                }

            }

        }
































        public async void GetSeatFromUser(int student_id, string user_id)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@student_id", student_id);
                s.Add("@user_id", user_id);
                connection.Execute("spGetSeatFromUser", s, commandType: CommandType.StoredProcedure);


            }

        }





        int seatState = 0;
        public async void GetSeatState(int student_id, string user_id)
        {
            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                // insert into the seat table
                var s = new DynamicParameters();

                s.Add("@user_id", user_id);
                s.Add("@student_id", student_id);
                s.Add("@seatState", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spGetSeatStateSEC", s, commandType: CommandType.StoredProcedure);

                try
                {
                    seatState = s.Get<int>("@seatState");
                }
                catch (Exception ex)
                {
                    
                }
               


             

            }
           

        }


             bool isLoggedIn = false;
        public void CheckLoginStatus( int student_id, string user_id)
        {



            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@user_id", user_id);
                s.Add("@student_id", student_id);
                s.Add("@isLoggedStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spIsLoggedInSEC", s, commandType: CommandType.StoredProcedure);


                int rst = 0;


                try
                {


                    rst = s.Get<int>("@isLoggedStatus");
                    if(rst == 1)
                    {
                        isLoggedIn = true;
                    }else 
                    
                    {

                        isLoggedIn = false;
                    }


                }
                catch (Exception ex)
                {
                    bool isLoggedIn = false;

                }

            }


            
        }



        public async void LoginSeatStatusUpdateTo_one(int student_id, string user_id)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@student_id", student_id);
                s.Add("@user_id", user_id);
                connection.Execute("loggedStatusUpdate_to_OneSEC", s, commandType: CommandType.StoredProcedure);


            }

        }

        //  update login state
        public async void LoginSeatStatusUpdateTo_zero(int student_id, string user_id)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@student_id", student_id);
                s.Add("@user_id", user_id);
                connection.Execute("loggedStatusUpdate_to_zeroSEC", s, commandType: CommandType.StoredProcedure);

            }

        }


        public async void LoginCheck(int studentId, string user_id)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@studentId", studentId);
                s.Add("@user_id", user_id);
                connection.Execute("spLoginCheckSEC", s, commandType: CommandType.StoredProcedure);


            }

        }



        StudentModel studentModel = new StudentModel();

        // table inset status
        public async void InsertSeatStatus()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();
                s.Add("@seat1_status", Seat1_status);
                s.Add("@seat2_status", Seat2_status);
                s.Add("@seat3_status", Seat3_status);
                s.Add("@seat4_status", Seat4_status);
                //s.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spSeatStatus_UpdateSEC", s, commandType: CommandType.StoredProcedure);
            }

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
                connection.Execute("dbo.spSeatCountSEC", s, commandType: CommandType.StoredProcedure);
                arduinoConnectModel.SeatsAvailable = s.Get<int>("@seatsAvailable");

            }
            return arduinoConnectModel.SeatsAvailable;
        }


        


























































































































































































































        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@StudentId", studentId);
        //        connection.Execute("dbo.spUpdateSeats_To_One", s, commandType: CommandType.StoredProcedure);


        //    }

        //}
























        //public async void AsignSeat(int seatId, string name, int yearOfStudy, int studentId)
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {

        //        var s = new DynamicParameters();

        //        s.Add("@cardId", cardId);
        //        s.Add("@seatId", seatId);
        //        s.Add("@name", name);
        //        s.Add("@yearOfStudy", yearOfStudy);
        //        s.Add("@studentId", studentId);

        //        connection.Execute("dbo.spAsignSeats", s, commandType: CommandType.StoredProcedure);


        //    }



        //      UpdateSeatsStatusTo_One(studentId);
        //     LoginSeatStatusUpdateTo_one(studentModel.StudentId);


        //}

        //public async void GetSeatFromUser(int studentId)
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@StudentId", studentId);
        //        connection.Execute("spUpdateSeats", s, commandType: CommandType.StoredProcedure);


        //    }

        //}


















        ////test method
        //int compareId =0;
        //int compareIdStatus =5;
        //public async void CompareId(int studentId )
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();
        //        s.Add("@studentId", studentId);
        //        s.Add("@compareIdStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        s.Add("@compareId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        connection.Execute("spGetCompareId", s, commandType: CommandType.StoredProcedure);

        //        try
        //        {

        //             compareId= s.Get<int>("@compareId");
        //            compareIdStatus = s.Get<int>("@compareIdStatus");
        //        }
        //        catch (Exception dbex)
        //        {
        //            return;
        //        }

        //    }

        //}



        //int compareSeatM =0;
        //public int CompareSeatM { get { return compareSeatM; } set { compareSeatM = value; } }

        //public async void CompareSeatStatus(int studentId)
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();
        //        s.Add("@studentId", studentId);
        //        s.Add("@compareSeatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        connection.Execute("spGet_SeatStatusToCompare", s, commandType: CommandType.StoredProcedure);

        //        try
        //        {

        //            compareSeatM = s.Get<int>("@compareSeatStatus");

        //        }
        //        catch (Exception dbex)
        //        {
        //            return;
        //        }

        //    }

        //}


































































        //  get seat status
        //public async void GetLoginSeatStatus(int studentId)
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@StudentId", studentId);
        //        s.Add("@loggedStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        connection.Execute("spGetLoginStatus", s, commandType: CommandType.StoredProcedure);



        //        try {
        //            CheckSeatState = s.Get<int>("@loggedStatus");

        //        } catch (Exception ex) {



        //        }        

        //    }

        //}


        //  update login state
        //public async void LoginSeatStatusUpdateTo_one(int studentId)
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@studentId", studentId);
        //        connection.Execute("dbo.loggedStatusUpdate_to_One", s, commandType: CommandType.StoredProcedure);

        //    }

        //}


        //  update login state
        //public async void LoginSeatStatusUpdateTo_zero(int studentId)
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@studentId", studentId);
        //        connection.Execute("dbo.loggedStatusUpdate_to_zero", s, commandType: CommandType.StoredProcedure);

        //    }

        //}

































































        //public int GetSeat_status(int studentId)
        //{


        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@StudentId", studentId);
        //        s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        s.Add("@seatTime", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        connection.Execute("dbo.spGet_seatStatus", s, commandType: CommandType.StoredProcedure);



        //        seatStatus = s.Get<int>("@seatStatus");
        //        SeatTime = s.Get<int>("@seatTime");


        //    }


        //    return SeatStatus;
        //}

        //public async void Get_specific_Seat1_status(int seatId)
        //{


        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@seatId", seatId);
        //        s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        s.Add("@awayTime", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        connection.Execute("dbo.spGet_SpecificSeatStatus1", s, commandType: CommandType.StoredProcedure);
        //        SpecSeatStatus1 = s.Get<int>("@seatStatus");
        //        AwayTime1 = s.Get<int>("@awayTime");


        //    }



        //}


        //public async void Get_specific_Seat2_status(int seatId)
        //{


        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@seatId", seatId);
        //        s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        s.Add("@awayTime", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        connection.Execute("dbo.spGet_SpecificSeatStatus2", s, commandType: CommandType.StoredProcedure);
        //        SpecSeatStatus2 = s.Get<int>("@seatStatus");
        //        AwayTime2 = s.Get<int>("@awayTime");


        //    }



        //}

        //public async void Get_specific_Seat3_status(int seatId)
        //{


        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@seatId", seatId);
        //        s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        s.Add("@awayTime", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        connection.Execute("dbo.spGet_SpecificSeatStatus3", s, commandType: CommandType.StoredProcedure);
        //        SpecSeatStatus3 = s.Get<int>("@seatStatus");
        //        AwayTime3 = s.Get<int>("@awayTime");


        //    }



        //}

        //public async void Get_specific_Seat4_status(int seatId)
        //{


        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@seatId", seatId);
        //        s.Add("@seatStatus", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        s.Add("@awayTime", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        connection.Execute("dbo.spGet_SpecificSeatStatus4", s, commandType: CommandType.StoredProcedure);
        //        SpecSeatStatus4 = s.Get<int>("@seatStatus");
        //        AwayTime4 = s.Get<int>("@awayTime");


        //    }



        //}



































        //public bool TimeOut(int seatId)
        //{
        //    int x = 0;
        //    //StudentModel studentModel = new StudentModel();
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {

        //        var s = new DynamicParameters();
        //        s.Add("@seatId", seatId);
        //        s.Add("@seatState", 0, dbType: DbType.String, direction: ParameterDirection.Output);
        //        connection.Execute("dbo.spSeatState", s, commandType: CommandType.StoredProcedure);

        //        // studentModel.SeatState = s.Get<int>("@seatState");
        //        x = s.Get<int>("@seatState");
        //        if (x == 0)
        //            return false;

        //    }


        //    return true; //studentModel.SeatState;
        //}









        //public async void GetStudentId(int card)
        //{

        //    cardId = card;
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {

        //        var s = new DynamicParameters();
        //        s.Add("@cardId", card);
        //        s.Add("@firstName", 0, dbType: DbType.String, direction: ParameterDirection.Output);
        //        s.Add("@year", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        s.Add("@studentId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        connection.Execute("dbo.spValidateLogin_Card", s, commandType: CommandType.StoredProcedure);
        //        studentModel.First_Name = s.Get<string>("@firstName");

        //        studentModel.Year = s.Get<int>("@year");
        //        studentModel.StudentId = s.Get<int>("@studentId");

        //    }

        //    GetFreeSeat();




        //}



        //// Available Seats
        //public int GetAvailableSeat()
        //{
        //    ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        // insert into the seat table
        //        var s = new DynamicParameters();


        //        s.Add("@seatsAvailable", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        connection.Execute("dbo.spSeatCount", s, commandType: CommandType.StoredProcedure);
        //        arduinoConnectModel.SeatsAvailable = s.Get<int>("@seatsAvailable");

        //    }
        //    return arduinoConnectModel.SeatsAvailable;
        //}



        //public async void updateSeatState1(int state)
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@state", state);
        //        connection.Execute("dbo.spUpdateSeatState1", s, commandType: CommandType.StoredProcedure);


        //    }

        //}

        //public async void updateSeatState2(int state)
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@state", state);
        //        connection.Execute("dbo.spUpdateSeatState2", s, commandType: CommandType.StoredProcedure);


        //    }

        //}

        //public async void updateSeatState3(int state)
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@state", state);
        //        connection.Execute("dbo.spUpdateSeatState3", s, commandType: CommandType.StoredProcedure);


        //    }

        //}

        //public async void updateSeatState4(int state)
        //{

        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {
        //        var s = new DynamicParameters();

        //        s.Add("@state", state);
        //        connection.Execute("dbo.spUpdateSeatState4", s, commandType: CommandType.StoredProcedure);


        //    }

        //}

    }
}
