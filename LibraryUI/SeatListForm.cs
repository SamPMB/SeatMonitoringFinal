using SeatMonitoringLibrary;

namespace LibraryUI
{
    public partial class SeatListForm : Form
    {
       
        
        DatabaseAccessModel databaseAccess = new DatabaseAccessModel();


        public SeatListForm(int s1, int s2, int s3, int s4)
        {
            InitializeComponent();
            ChangeSeatStatus(s1,s2,s3,s4);
        }

       


        private void SeatListModel_Load(object sender, EventArgs e)
        {
          
           

        }

        private void seat3_Click(object sender, EventArgs e)
        {



        }

        public async void ChangeSeatStatus(int s1, int s2, int s3, int s4)
        {
            if (s1 == 0)
            {
                seat1Label.BackColor = Color.Blue;
            }
            else
            {
                seat1Label.BackColor = Color.Red;
            }
            if (s4 == 0)
            {
                seat2Lable.BackColor = Color.Blue;
            }
            else
            {
                seat2Lable.BackColor = Color.Red;
            }
            if (s3 == 0)
            {
                seat3Label.BackColor = Color.Blue;
            }
            else
            {
                seat3Label.BackColor = Color.Red;
            }
            if (s2 == 0)
            {
                seat4Label.BackColor = Color.Blue;
            }
            else
            {
                seat4Label.BackColor = Color.Red;
            }


        }

        private void backButton_Click(object sender, EventArgs e)
        {

           // ChangeSeatStatus();

        }



    }

}
























