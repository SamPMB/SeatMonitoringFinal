using Dapper;
using SeatMonitoringLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryUI
{
    public partial class RegisterForm : Form
    {



        public RegisterForm()
        {
            InitializeComponent();

            registerRole.Items.Add("Admin");
            registerRole.Items.Add("Staff");
        }

        private void registerUserButton_Click(object sender, EventArgs e)
        {











        }


        async void Register(string password, string user_name, string role)
        {
          

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@user_name", user_name);
                s.Add("@password", password);
                s.Add("@role", role);
                connection.Execute("spRegisterUserSEC", s, commandType: CommandType.StoredProcedure);

            }
           
            MessageBox.Show("Registered successfully!");
             userNameRegister.Text ="";
             userpasswordRegister.Text ="";
            
        }


         string Encrypt(string message, string key)
        {
            char[] encryptedMessage = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                char messageChar = message[i];
                char keyChar = key[i % key.Length];

                encryptedMessage[i] = (char)(messageChar ^ keyChar);
            }

            return new string(encryptedMessage);
        }


        // decrypted

     











        private void loginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loginPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void registerRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void registerUserButton_Click_1(object sender, EventArgs e)
        {

            string user_name = userNameRegister.Text;
            string password = userpasswordRegister.Text;
            string role = registerRole.Text;
            string comfirm = "";
            comfirm = comfirmPassword.Text;

            if(password == comfirm)
            {
                // Register(password, user_name, role);
                Register(Encrypt(password, "SECRETKEY"), user_name, role);
            }
            else 
            {

                MessageBox.Show("Passwords dont match!");
               
                comfirmPassword.Text = "";
            }

         

        }
    }
}
