using SeatMonitoringLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Timers;
using Timer = System.Timers.Timer;
using Dapper;

namespace LibraryUI
{
    public partial class LibraryDashboardForm : Form
    {
        // Create a timer object
        private Timer timer1 = new Timer();
        private Timer timer2 = new Timer();
        private Timer timer3 = new Timer();
        private Timer timer4 = new Timer();

        TimerModel timerModel = new TimerModel();
        SeatListForm seatListForm = new SeatListForm();
        int seat1_timer = 100;
        int seat2_timer = 100;
        int seat3_timer = 100;
        int seat4_timer = 100;

       

        public LibraryDashboardForm()
        {
            InitializeComponent();
            displayData();
            ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();
           // availableSeatsLabel.Text = arduinoConnectModel.GetAvailableSeat().ToString();


            // Initialize the timer with a 5-second interval
            timer1 = new Timer(1000);
            timer2 = new Timer(1000);
            timer3 = new Timer(1000);
            timer4 = new Timer(1000);


            // Attach an event handler for the timer's Elapsed event
            timer1.Elapsed += Timer1_Elapsed;
            timer2.Elapsed += Timer2_Elapsed;
            timer3.Elapsed += Timer3_Elapsed;
            timer4.Elapsed += Timer4_Elapsed;

        }

        public LibraryDashboardForm( string Name)
        {
            InitializeComponent();
            displayData();
            GetAllSeatTime();
            adminName.Text = Name;
            ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();
            availableSeatsLabel.Text = arduinoConnectModel.GetAvailableSeat().ToString();
            // Initialize the timer with a 5-second interval
            timer1 = new Timer(1000);
            timer2 = new Timer(500);
            timer3 = new Timer(1000);
            timer4 = new Timer(500);

            // Attach an event handler for the timer's Elapsed event
            timer1.Elapsed += Timer1_Elapsed;
            timer2.Elapsed += Timer2_Elapsed;
            timer3.Elapsed += Timer3_Elapsed;
            timer4.Elapsed += Timer4_Elapsed;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            // Start the timer when the form is loaded
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
        }

        public void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Create an instance of the OtherClass
            

            // Call a method on the OtherClass
        

            // Perform any necessary UI updates on the main UI thread
            Invoke(new Action(() =>
            {
                // Update UI elements if needed




                 counterDataGrid[3, 0].Value = (seat1_timer--).ToString();
                
               
               



            }));
        }

        public void Timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Create an instance of the OtherClass


            // Call a method on the OtherClass


            // Perform any necessary UI updates on the main UI thread
            Invoke(new Action(() =>
            {
                // Update UI elements if needed

                counterDataGrid[3, 1].Value = (seat2_timer--).ToString();


                
            }));
        }

        public void Timer3_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Create an instance of the OtherClass


            // Call a method on the OtherClass


            // Perform any necessary UI updates on the main UI thread
            Invoke(new Action(() =>
            {
                // Update UI elements if needed




                counterDataGrid[3, 2].Value = (seat3_timer--).ToString();
            }));
        }

        public void Timer4_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Create an instance of the OtherClass


            // Call a method on the OtherClass


            // Perform any necessary UI updates on the main UI thread
            Invoke(new Action(() =>
            {
                // Update UI elements if needed




                counterDataGrid[3, 3].Value = (seat4_timer--).ToString();
            }));
        }


        // table inset seat timer
        public void InsertAllTime()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
              
                var s = new DynamicParameters();

                s.Add("@seat1_timer", seat1_timer);
                s.Add("@seat2_timer", seat2_timer);
                s.Add("@seat3_timer", seat3_timer);
                s.Add("@seat4_timer", seat4_timer);

               // s.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spInsertAllTimer", s, commandType: CommandType.StoredProcedure);
                //id = s.Get<int>("@id");

            }

        }


        // table Get timers
        public void GetAllSeatTime()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seat1_timer", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@seat2_timer", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@seat3_timer", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                s.Add("@seat4_timer", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spGetAll_timer", s, commandType: CommandType.StoredProcedure);

                seat1_timer = s.Get<int>("@seat1_timer");
                seat2_timer = s.Get<int>("@seat2_timer");
                seat3_timer = s.Get<int>("@seat3_timer");
                seat4_timer = s.Get<int>("@seat4_timer");


            }

        }

































        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void available_Click(object sender, EventArgs e)
        {

            seatListForm.ChangeSeatStatus();
            // this.Hide();
            try
            {
                   seatListForm.ChangeSeatStatus();
                seatListForm.ShowDialog();
            }
            catch(ObjectDisposedException e2)
            {
                SeatListForm seatListForm = new SeatListForm();
                seatListForm.Show();
            }
           

            

        }

        private void counterDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void logout_Click(object sender, EventArgs e)
        {
           
            InsertAllTime();
            LoginForm loginForm = new LoginForm();

            this.Hide();
            loginForm.Show();
        }


        void displayData()
        {

            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                using (SqlCommand cmd = new SqlCommand("spStudents_GetAll", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    DataTable dt = new DataTable();
                        

                    SqlDataReader sqlDr = cmd.ExecuteReader();
                    dt.Load(sqlDr);

                    counterDataGrid.DataSource = dt;

                    connection.Close();


                }

            }

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();
           availableSeatsLabel.Text = arduinoConnectModel.GetAvailableSeat().ToString();
        }
    }
}