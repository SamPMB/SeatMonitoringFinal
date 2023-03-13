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
    public partial class LoginForm : Form
    {
       

        public LoginForm()
        {
            InitializeComponent();

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            LibraryDashboardForm libraryDashboard = new LibraryDashboardForm(userName.Text);
            StaffModel staffModel = new StaffModel();



            string pwd = password.Text;


            if (staffModel.StaffLoginInValidation(pwd))
            {
                this.Hide();
                libraryDashboard.Show();
            }




        }

        public void OpenDashboard()
        {
            LibraryDashboardForm libraryDashboard = new LibraryDashboardForm();
            
            this.Hide();
            libraryDashboard.Show();

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
