using System.Data;
using System.Data.SqlClient;

namespace SeatMonitoringLibrary
{
    public class SecurityModel
    {
        bool validate = false;
        public bool Validate { get { return validate; } set { validate = value; } }

        // validate  card
        public bool StaffLoginInValidation(string staffId)
        {
            StaffModel staffModel = new StaffModel();
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {


                using (SqlCommand cmd = new SqlCommand("spStaffLoginValidate", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@StaffId", staffId);




                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }


                    DataTable loginDataTable = new DataTable();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    ////check if the data retrieve matches user information entered
                    if (dataReader.HasRows)
                    {



                        return true;
                    }
                    else
                    {
                        // MessageBox.Show("User does not exist!");
                        Console.WriteLine("not match");
                    }
                    connection.Close();
                }



                return false;

            }

        }

    }
}
