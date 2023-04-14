using Dapper;
using SeatMonitoringLibrary;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Timers;
using Timer = System.Timers.Timer;




namespace LibraryUI
{
    public partial class LibraryDashboardForm : Form
    {
        private SerialPort _serialPort;
        public bool getData = false;
        // Create a timer object
        private Timer timer1 = new Timer();
        private Timer timer2 = new Timer();
        private Timer timer3 = new Timer();
        private Timer timer4 = new Timer();
        private Timer timer5 = new Timer();

        TimerModel timerModel = new TimerModel();
        SeatListForm seatListForm = new SeatListForm();
        int seat1_timer = 100;
        int seat2_timer = 100;
        int seat3_timer = 100;
        int seat4_timer = 100;
        int seat5_timer = 9;
        public int Seat1_timer { get { return seat1_timer; } set { seat1_timer = value; } }
        public int Seat2_timer { get { return seat2_timer; } set { seat2_timer = value; } }
        public int Seat3_timer { get { return seat3_timer; } set { seat3_timer = value; } }
        public int Seat4_timer { get { return seat4_timer; } set { seat4_timer = value; } }
        public int Seat5_timer { get { return seat5_timer; } set { seat5_timer = value; } }




        public LibraryDashboardForm()
        {
            InitializeComponent();
            Thread.Sleep(5000);
            displayData();
            ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();
            // availableSeatsLabel.Text = arduinoConnectModel.GetAvailableSeat().ToString();

            //timer






            // Initialize the timer with a 5-second interval
            timer1 = new Timer(1000);
            timer2 = new Timer(1000);
            timer3 = new Timer(1000);
            timer4 = new Timer(1000);
            timer5 = new Timer(1000);


            // Attach an event handler for the timer's Elapsed event
            timer1.Elapsed += Timer1_Elapsed;
            timer2.Elapsed += Timer2_Elapsed;
            timer3.Elapsed += Timer3_Elapsed;
            timer4.Elapsed += Timer4_Elapsed;
            timer5.Elapsed += Timer5_Elapsed;


        }

        public LibraryDashboardForm(string Name)
        {
            InitializeComponent();
            displayData();
            GetAllSeatTime();
            adminName.Text = Name;
            //ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();
            DatabaseAccessModel databaseAccessModel = new DatabaseAccessModel();
            //availableSeatsLabel.Text = arduinoConnectModel.GetAvailableSeat().ToString();
            availableSeatsLabel.Text = databaseAccessModel.GetAvailableSeat().ToString();
            // Initialize the timer with a 5-second interval
            timer1 = new Timer(1000);
            timer2 = new Timer(500);
            timer3 = new Timer(1000);
            timer4 = new Timer(500);
            timer5 = new Timer(1000);

            // Attach an event handler for the timer's Elapsed event
            timer1.Elapsed += Timer1_Elapsed;
            timer2.Elapsed += Timer2_Elapsed;
            timer3.Elapsed += Timer3_Elapsed;
            timer4.Elapsed += Timer4_Elapsed;
            timer5.Elapsed += Timer5_Elapsed;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Start the timer when the form is loaded
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();

        }

        public void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Create an instance of the OtherClass


            // Call a method on the OtherClass


            // Perform any necessary UI updates on the main UI thread
            Invoke(new Action(() =>
            {
                // Update UI elements if needed


                try
                {

                    counterDataGrid[3, 0].Value = (seat1_timer--).ToString();

                }
                catch (Exception ex)
                {


                }








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




                try
                {

                    counterDataGrid[3, 1].Value = (seat2_timer--).ToString();

                }
                catch (Exception ex)
                {


                }





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



                try
                {

                    counterDataGrid[3, 2].Value = (seat3_timer--).ToString();

                }
                catch (Exception ex)
                {


                }





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



                try
                {

                    counterDataGrid[3, 3].Value = (seat4_timer--).ToString();

                }
                catch (Exception ex)
                {


                }




            }));
        }



        public void Timer5_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Create an instance of the OtherClass


            // Call a method on the OtherClass

            if (getData)
            {
                // Perform any necessary UI updates on the main UI thread
                Invoke(new Action(() =>
                {
                    string data = _serialPort.ReadLine();


                    String check = "0 ";
                    char[] separator = { ',' };

                    string[] myArray = data.Split(separator);

                    if (myArray[0].Length == check.Length)
                    {
                        string seat1 = myArray[0];
                        displayseat1.Text = seat1;
                        string seat2 = myArray[1];
                        displayseat2.Text = seat2;
                        string seat3 = myArray[2];
                        displayseat3.Text = seat3;
                        string seat4 = myArray[3];
                        displayseat4.Text = seat4;

                    }
                    else
                    {
                        string cardId = myArray[0];
                        displaycard.Text = cardId;




                    }


                }));
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
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


            try
            {
                seatListForm.ChangeSeatStatus();
                seatListForm.Show();
            }
            catch (ObjectDisposedException e2)
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
            DatabaseAccessModel databaseAccessModel = new DatabaseAccessModel();

            // databaseAccessModel.InsertSeatStatus();
            databaseAccessModel.GetAvailableSeat();
            databaseAccessModel.VerifyStudentId("3A 4C 84 G3");
            displayData();
            availableSeatsLabel.Text = databaseAccessModel.GetAvailableSeat().ToString();
        }














        // other code



        private void connectBT_Click(object sender, EventArgs e)
        {



            //string data = _serialPort.ReadLine();
            //display.Text = "Received data: " + data;






        }

        private void outgoingTB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openPort_Click(object sender, EventArgs e)
        {



            _serialPort = new SerialPort();
            _serialPort.PortName = "COM9";
            _serialPort.BaudRate = 115200;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.Open();

            open.Text = "Serial port opened.";
            getData = true;

        }



        private void display_Click(object sender, EventArgs e)
        {

        }




        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {


        }

        private void displayseat2_Click(object sender, EventArgs e)
        {

        }
    }


}
