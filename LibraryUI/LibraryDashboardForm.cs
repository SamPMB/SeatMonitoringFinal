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
        private SerialPort _serialPortId;
        public bool getData = false;
        // Create a timer object
        private Timer timer1 = new Timer();
        private Timer timer2 = new Timer();
        private Timer timer3 = new Timer();
        private Timer timer4 = new Timer();
        private Timer timer5 = new Timer();
        int index1 = 0;
        int index2 = 0;
        int index3 = 0;
        int index4 = 0;
        int incrementIndex = 0;



        TimerModel timerModel = new TimerModel();
        // SeatListForm seatListForm = new SeatListForm();
        int seat1_timer = 0;
        int seat2_timer = 0;
        int seat3_timer = 0;
        int seat4_timer = 0;
        public int Seat1_timer { get { return seat1_timer; } set { seat1_timer = value; } }
        public int Seat2_timer { get { return seat2_timer; } set { seat2_timer = value; } }
        public int Seat3_timer { get { return seat3_timer; } set { seat3_timer = value; } }
        public int Seat4_timer { get { return seat4_timer; } set { seat4_timer = value; } }
        // public int Seat5_timer { get { return seat5_timer; } set { seat5_timer = value; } }



        DatabaseAccessModel databaseAccessModel = new DatabaseAccessModel();

        public LibraryDashboardForm()
        {
            InitializeComponent();
            displayData();
            ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();

            // Initialize the timer with a 5-second interval
            timer1 = new Timer(1000);
            timer2 = new Timer(500);
            timer3 = new Timer(1500);
            timer4 = new Timer(2000);
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
            //displayData();
            GetAllSeatTime();
            adminName.Text = Name;
            //availableSeatsLabel.Text = databaseAccessModel.GetAvailableSeat().ToString();

            // Initialize the timer with a 5-second interval
            timer1 = new Timer(500);
            timer2 = new Timer(500);
            timer3 = new Timer(500);
            timer4 = new Timer(500);
            timer5 = new Timer(10000);

            // Attach an event handler for the timer's Elapsed event
            timer1.Elapsed += Timer1_Elapsed;
            timer2.Elapsed += Timer2_Elapsed;
            timer3.Elapsed += Timer3_Elapsed;
            timer4.Elapsed += Timer4_Elapsed;
            timer5.Elapsed += Timer5_Elapsed;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;
            Label.CheckForIllegalCrossThreadCalls = false;
            ComboBox.CheckForIllegalCrossThreadCalls = false;

        }



        public void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Perform any necessary UI updates on the main UI thread
            Invoke(new Action(() =>
            {








            }));
        }





        public void Timer2_Elapsed(object sender, ElapsedEventArgs e)
        {

            Invoke(new Action(() =>
            {



            }));
        }

        public void Timer3_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {

            }));
        }

        public void Timer4_Elapsed(object sender, ElapsedEventArgs e)
        {


            // Perform any necessary UI updates on the main UI thread
            Invoke(new Action(() =>
            {

            }));
        }


        public void Timer5_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                displayData();
                //InsertAllTime();
                availableSeatsLabel.Text = databaseAccessModel.GetAvailableSeat().ToString();

            }));
        }



































        int j = 0;
        int i = 0;
        // table inset seat timer
        public async void InsertAllTime()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnString("LibraryDb")))
            {
                var s = new DynamicParameters();

                s.Add("@seat1_timer", Seat1_timer);
                s.Add("@seat2_timer", Seat2_timer);
                s.Add("@seat3_timer", Seat3_timer);
                s.Add("@seat4_timer", Seat4_timer);

                // s.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spInsertAllTimer", s, commandType: CommandType.StoredProcedure);
                //id = s.Get<int>("@id");

            }

        }


        // table Get timers
        public async void GetAllSeatTime()
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
                SeatListForm seatListForm = new SeatListForm(s1, s2, s3, s4);
                seatListForm.Show();

                //seatListForm.ChangeSeatStatus();
                //seatListForm.Show();
            }
            catch (ObjectDisposedException e2)
            {
                SeatListForm seatListForm = new SeatListForm(s1, s2, s3, s4);
                seatListForm.Show();
            }




        }

        private void counterDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void logout_Click(object sender, EventArgs e)
        {

            InsertAllTime();
            LoginForm1 loginForm = new LoginForm1();

            this.Hide();
            loginForm.Show();
        }


        async void displayData()
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



                    try
                    {
                        SqlDataReader sqlDr = cmd.ExecuteReader();
                        dt.Load(sqlDr);
                        counterDataGrid.DataSource = dt;
                    }
                    catch (Exception esr)
                    {


                    }



                    connection.Close();


                }

            }

        }




        private void refreshButton_Click(object sender, EventArgs e)
        {
            // DatabaseAccessModel databaseAccessModel = new DatabaseAccessModel();

            // databaseAccessModel.InsertSeatStatus();
            databaseAccessModel.GetAvailableSeat();
            displayData();
            availableSeatsLabel.Text = databaseAccessModel.GetAvailableSeat().ToString();
        }






        // other code
        private void connectBT_Click(object sender, EventArgs e)
        {








        }

        private void outgoingTB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openPort_Click(object sender, EventArgs e)
        {

            _serialPort = new SerialPort();
            _serialPort.PortName = "COM6";
            _serialPort.BaudRate = 9600;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            // _serialPort.Open();




            _serialPortId = new SerialPort();
            _serialPortId.PortName = "COM5";
            _serialPortId.BaudRate = 9600;
            _serialPortId.DataBits = 8;
            _serialPortId.StopBits = StopBits.One;
            _serialPortId.Parity = Parity.None;
            // _serialPortId.Open();


            Thread seatThread = new Thread(ReadSeatStatus);
            seatThread.Start();


            openPort.Enabled = false;

            Thread.Sleep(2000);
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();
            Thread.Sleep(1000);
            displayData();

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void enter_Click(object sender, EventArgs e)
        {
            // DatabaseAccessModel databaseAccessModel = new DatabaseAccessModel();

            displayData();
            availableSeatsLabel.Text = databaseAccessModel.GetAvailableSeat().ToString();
            databaseAccessModel.updateSeats(19143648);

            displayData();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {


        }


        int s1;
        int s2;
        int s3;
        int s4;

        public void ReadSeatStatus()
        {

            // DatabaseAccessModel databaseAccessModel = new DatabaseAccessModel();
            string globalVa = "5,5,5,5";
            string globalVaId = "id";

            ArduinoConnectModel connectModel = new ArduinoConnectModel();
            while (true)
            {

                try
                {


                    if (!_serialPort.IsOpen)
                    {
                        _serialPort = new SerialPort();
                        _serialPort.PortName = "COM6";
                        _serialPort.BaudRate = 9600;
                        _serialPort.DataBits = 8;
                        _serialPort.StopBits = StopBits.One;
                        _serialPort.Parity = Parity.None;
                        _serialPort.Open();


                        char[] separator = { ',' };

                        try
                        {
                            globalVa = _serialPort.ReadLine();
                            string[] myArray = globalVa.Split(separator);
                            databaseAccessModel.Seat1_status = int.Parse(myArray[0]);
                            databaseAccessModel.Seat2_status = int.Parse(myArray[1]);
                            databaseAccessModel.Seat3_status = int.Parse(myArray[2]);
                            databaseAccessModel.Seat4_status = int.Parse(myArray[3]);

                            s1 = int.Parse(myArray[0]);
                            s2 = int.Parse(myArray[1]);
                            s3 = int.Parse(myArray[2]);
                            s4 = int.Parse(myArray[3]);




                            seatData.Text = globalVa;
                            databaseAccessModel.InsertSeatStatus();
                            Thread.Sleep(1000);
                            seatData.Text = "";

                        }
                        catch (Exception ex)
                        {
                            databaseAccessModel.InsertSeatStatus();
                            _serialPort.Close();

                        }

                        Thread.Sleep(1000);
                        _serialPort.Close();


                    }
                    else
                    {
                        char[] separator = { ',' };

                        globalVa = _serialPort.ReadLine();
                        string[] myArray = globalVa.Split(separator);
                        databaseAccessModel.Seat1_status = int.Parse(myArray[0]);
                        databaseAccessModel.Seat2_status = int.Parse(myArray[1]);
                        databaseAccessModel.Seat3_status = int.Parse(myArray[2]);
                        databaseAccessModel.Seat4_status = int.Parse(myArray[3]);

                        s1 = int.Parse(myArray[0]);
                        s2 = int.Parse(myArray[1]);
                        s3 = int.Parse(myArray[2]);
                        s4 = int.Parse(myArray[3]);


                        seatData.Text = globalVa;
                        Thread.Sleep(1000);
                        seatData.Text = myArray[3];
                        databaseAccessModel.InsertSeatStatus();
                        globalVa = _serialPort.ReadLine();
                        seatData.Text = globalVa;
                        Thread.Sleep(500);
                        seatData.Text = "";

                        if (!timer1.Enabled)
                        {
                            timer1.Start();
                        }
                        if (!timer2.Enabled)
                        {
                            timer2.Start();
                        }
                        if (!timer3.Enabled)
                        {
                            timer3.Start();
                        }
                        if (!timer4.Enabled)
                        {
                            timer4.Start();
                        }














                        _serialPort.Close();



                    }

                }


                catch (Exception seatThead)
                {
                    _serialPort = new SerialPort();
                    _serialPort.PortName = "COM6";
                    _serialPort.BaudRate = 9600;
                    _serialPort.DataBits = 8;
                    _serialPort.StopBits = StopBits.One;
                    _serialPort.Parity = Parity.None;
                    _serialPort.Open();
                    globalVa = _serialPort.ReadLine();
                    seatData.Text = globalVa;
                    databaseAccessModel.InsertSeatStatus();
                    Thread.Sleep(1000);
                    seatData.Text = "";
                    _serialPort.Close();

                }









                // second port


                try
                {
                    StudentModel studentModel = new StudentModel();

                    if (!_serialPortId.IsOpen)
                    {
                        _serialPortId = new SerialPort();
                        _serialPortId.PortName = "COM5";
                        _serialPortId.BaudRate = 9600;
                        _serialPort.DataBits = 8;
                        _serialPortId.StopBits = StopBits.One;
                        _serialPortId.Parity = Parity.None;
                        _serialPortId.Open();


                        try
                        {

                            globalVaId = _serialPortId.ReadLine();
                            textBoxId.Text = globalVaId;
                            string id = globalVaId.Trim();

                            databaseAccessModel.VerifyStudent(id);
                            Thread.Sleep(1000);
                            textBoxId.Text = "";
                            globalVaId = "";
                        }

                        catch (Exception ex)
                        {
                            globalVaId = _serialPortId.ReadLine();
                            textBoxId.Text = globalVaId;
                            string id = globalVaId.Trim();

                            databaseAccessModel.VerifyStudent(id);
                            Thread.Sleep(1000);
                            textBoxId.Text = "";
                            globalVaId = "";
                            _serialPortId.Close();

                            globalVaId = "";

                        }


                        _serialPortId.Close();


                    }
                    else
                    {
                        // string globalVaId = "";
                        globalVaId = _serialPortId.ReadLine();
                        textBoxId.Text = globalVaId;
                        string id = globalVaId.Trim();
                        databaseAccessModel.VerifyStudent(id);
                        Thread.Sleep(500);
                        textBoxId.Text = "";
                        globalVaId = "";

                        _serialPortId.Close();



                    }

                }


                catch (Exception seatThead)
                {

                    StudentModel studentModel = new StudentModel();
                    int checkSeat_status = 0;
                    //string global;
                    _serialPortId = new SerialPort();
                    _serialPortId.PortName = "COM5";
                    _serialPortId.BaudRate = 9600;
                    _serialPortId.DataBits = 8;
                    _serialPortId.StopBits = StopBits.One;
                    _serialPortId.Parity = Parity.None;
                    _serialPortId.Open();
                    globalVaId = _serialPortId.ReadLine();
                    textBoxId.Text = globalVaId;
                    string id = globalVaId.Trim();
                    databaseAccessModel.VerifyStudent(id);
                    textBoxId.Text = "";
                    Thread.Sleep(1000);
                    _serialPortId.Close();

                }

            }// endof while




        }// end of read thread

        private void seatData_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

