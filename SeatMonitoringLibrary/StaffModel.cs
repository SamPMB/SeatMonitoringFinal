using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SeatMonitoringLibrary
{
    public class StaffModel
    {

        string staffId;
        string staffType;
        string staffName;
        public string StaffId { get { return staffId; } set { staffId = value; } }
        public string StaffType { get { return staffType; } set { staffType = value; } }
        public string StaffName { get { return staffName; } set { staffName = value; } }






        //// validate  card
        //public bool StaffLoginInValidation(string staffId)
        //{
        //    using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
        //    {


        //        using (SqlCommand cmd = new SqlCommand("spStaffLoginValidate", connection))
        //        {

        //            cmd.CommandType = CommandType.StoredProcedure;


        //            cmd.Parameters.AddWithValue("@StaffId", Id);




        //            if (connection.State != ConnectionState.Open)
        //            {
        //                connection.Open();
        //            }


        //            DataTable loginDataTable = new DataTable();
        //            SqlDataReader dataReader = cmd.ExecuteReader();

        //            ////check if the data retrieve matches user information entered
        //            if (dataReader.HasRows)
        //            {
        //                //DO SOMETHING
        //                return true;
        //            }
        //            else
        //            {
        //                // MessageBox.Show("User does not exist!");
        //                Console.WriteLine("not match");
        //            }
        //            connection.Close();
        //        }



        //        return false;

        //    }

        //}





















    }




}

