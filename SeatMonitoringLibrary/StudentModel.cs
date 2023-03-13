using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;



namespace SeatMonitoringLibrary
{
    public class StudentModel
    {
        int studentId;
        int cardId;
        int seatId;
        int year  = 4;
        long awayTime;
        string FirstName ;
        
        public int Id { get { return cardId; } set { cardId = value; } } 
        public string Name { get { return FirstName; } set { FirstName = value; }}
        public int Seat { get { return seatId; } set { seatId = value; } }
        public long AwayTime { get { return awayTime;} set { awayTime = value; } }
        public int Year { get { return year; } set { year = value; } }
        public int StudentId { get { return studentId; } set { studentId = value; } }









        //srudent login
        public void VerifyStudentId(string cardId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {

                var s = new DynamicParameters();

                s.Add("@cardId",cardId);
               

                 s.Add("@firstName", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                 s.Add("@year", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                 s.Add("@studentId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spValidateLogin_Card", s, commandType: CommandType.StoredProcedure);
                FirstName = s.Get<string>("@firstName");
                year = s.Get<int>("@year");
                studentId = s.Get<int>("@studentId");

            }

            GetFreeSeat();

        }




        public void GetFreeSeat()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seatId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spGetFreeSeat", s, commandType: CommandType.StoredProcedure);

                seatId = s.Get<int>("@seatId");
            }

            AsignSeat(seatId, FirstName, year, studentId);
        }






        // asign seat
        public void AsignSeat(int seatId,string name,int yearOfStudy, int studentId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {

                var s = new DynamicParameters();

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























    }
}
