using SeatMonitoringLibrary;

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
            // StaffModel staffModel = new StaffModel();
            SecurityModel securityModel = new SecurityModel();



            string pwd = password.Text;


            if (securityModel.StaffLoginInValidation(pwd))
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
