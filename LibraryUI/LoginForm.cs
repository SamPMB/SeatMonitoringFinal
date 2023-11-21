using SeatMonitoringLibrary;
using System.Windows.Forms;

namespace LibraryUI
{
    public partial class LoginForm1 : Form
    {


        public LoginForm1()
        {
            InitializeComponent();

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void s(object sender, EventArgs e)
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
            //Encrypt(pwd, "SECRETKEY")


            //if (securityModel.StaffLoginInValidation(pwd))
            if (securityModel.StaffLoginInValidation(Encrypt(pwd, "SECRETKEY")))
            {
                this.Hide();
                libraryDashboard.Show();
            }
            else
            {
                MessageBox.Show("Incorrect login details!!", "Error");

            }




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
