using Dapper;
using System.Data;

namespace SeatMonitoringLibrary
{
    public class DatabaseAccessModel
    {
        int cardId;
        StudentModel studentModel = new StudentModel();

        // table inset status
        public void InsertSeatStatus()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                // insert into the seat table
                var s = new DynamicParameters();
                ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();
                s.Add("@seat1_status", arduinoConnectModel.Seat1_status);
                s.Add("@seat2_status", arduinoConnectModel.Seat2_status);
                s.Add("@seat3_status", arduinoConnectModel.Seat3_status);
                s.Add("@seat4_status", arduinoConnectModel.Seat4_status);
                s.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spSeatStatus_Insert", s, commandType: CommandType.StoredProcedure);
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
                connection.Execute("dbo.spSeatCount", s, commandType: CommandType.StoredProcedure);
                arduinoConnectModel.SeatsAvailable = s.Get<int>("@seatsAvailable");

            }
            return arduinoConnectModel.SeatsAvailable;

        }

        public void GetStudentId(int card)
        {

            cardId = card;
            //StudentModel studentModel = new StudentModel();
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

        public void VerifyStudent(string userId)
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
                studentModel.StudentId = s.Get<int>("@studentId");

            }

            GetFreeSeat();

        }

































        public void GetFreeSeat()
        {
            //StudentModel studentModel = new StudentModel();
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
            if (isLoggedIn(studentModel.StudentId))
            {
                updateSeats(studentModel.StudentId);

                return;

            }
            else
            {
                AsignSeat(studentModel.Seat, studentModel.First_Name, studentModel.Year, studentModel.StudentId);
            }


        }


        // asign seat
        public void AsignSeat(int seatId, string name, int yearOfStudy, int studentId)
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
                    // updateSeats(studentModel.StudentId);
                    return false;
                }


                //if (rst > 0)
                //    return true;


            }


            return true;
        }


        public void updateSeats(int studentId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@StudentId", studentId);
                connection.Execute("dbo.spUpdateSeats", s, commandType: CommandType.StoredProcedure);


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



        public void updateSeatState1(int state)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@state", state);
                connection.Execute("dbo.spUpdateSeatState1", s, commandType: CommandType.StoredProcedure);


            }

        }

        public void updateSeatState2(int state)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@state", state);
                connection.Execute("dbo.spUpdateSeatState2", s, commandType: CommandType.StoredProcedure);


            }

        }

        public void updateSeatState3(int state)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@state", state);
                connection.Execute("dbo.spUpdateSeatState3", s, commandType: CommandType.StoredProcedure);


            }

        }

        public void updateSeatState4(int state)
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
