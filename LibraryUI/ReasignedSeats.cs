using Dapper;
using Guna.UI2.WinForms;
using SeatMonitoringLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryUI
{
    public partial class ReasignedSeats : Form
    {
        public ReasignedSeats()
        {
            InitializeComponent();

            DisplayData();

        }











        async public void DisplayData()
        {

            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                using (SqlCommand cmd = new SqlCommand("spStudents_TimeOutSEC", connection))
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
                        dataGrid.DataSource = dt;

                    }
                    catch (Exception esr)
                    {


                    }



                    connection.Close();


                }

            }

        }


        async public void DisplayCharge()
        {

            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                using (SqlCommand cmd = new SqlCommand("spTotalChage", connection))
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
                        dataGrid.DataSource = dt;

                    }
                    catch (Exception esr)
                    {


                    }



                    connection.Close();


                }

            }

        }






















        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void ReasignedSeats_Load(object sender, EventArgs e)
        {

        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)


        {

            if (e.RowIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                int student_id = Convert.ToInt32(selectedRow.Cells["student_id"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete the row with ID " + student_id + "?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dataGridView.Rows.RemoveAt(e.RowIndex);

                    DeleteRow(student_id);
                    DisplayData();
                }
            }






            async void DeleteRow(int student_id)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
                {
                    var s = new DynamicParameters();

                    s.Add("@student_id", student_id);
                    connection.Execute("spDeleteRowSEC", s, commandType: CommandType.StoredProcedure);

                }

            }


        }

        private void TimeOutbutton_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void ChargeButton_Click(object sender, EventArgs e)
        {
            DisplayCharge();


        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetAllcharges();
            DisplayCharge();
        }






        public async void ResetAllcharges()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

               
                
                connection.Execute("spIResetCharges", s, commandType: CommandType.StoredProcedure);
               

            }

        }
















    }
}

