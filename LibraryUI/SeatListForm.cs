﻿using SeatMonitoringLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryUI
{
    public partial class SeatListForm : Form
    {
        int count;
       ArduinoConnectModel arduino = new ArduinoConnectModel();
        
      
        public SeatListForm()
        {
            InitializeComponent();
        }

        public SeatListForm(int count)
        {
            InitializeComponent();
            this.count = count;

        }


        private void SeatListModel_Load(object sender, EventArgs e)
        {
            LibraryDashboardForm dashboardForm = new LibraryDashboardForm();

            
        }

        private void seat3_Click(object sender, EventArgs e)
        {


            
        }

       public void ChangeSeatStatus()
        {
            if ( arduino.Seat1_status == 1)
            {
                seat1Label.BackColor = Color.Blue;
            }
            else
            {
                seat1Label.BackColor = Color.Red;
            }
            if (arduino.Seat2_status == 1)
            {
                seat2Lable.BackColor = Color.Blue;
            }
            else
            {
                seat2Lable.BackColor = Color.Red;
            }
            if (arduino.Seat3_status == 1)
            {
                seat3Label.BackColor = Color.Blue;
            }
            else
            {
                seat3Label.BackColor = Color.Red;
            }
            if (arduino.Seat3_status == 1)
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
          LibraryDashboardForm dashboard = new LibraryDashboardForm();


          
          
               this.Hide();
            dashboard.Show();
            
            
        }
       


    }

}





















   
    

