using System.Net.Sockets;
using System.Net;
using System.Text;
using SeatMonitoringLibrary;
namespace LibraryUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ArduinoConnectModel arduinoConnectModel = new ArduinoConnectModel();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Parallel.Invoke(() => arduinoConnectModel.ArduinoConnect())
              
                //arduinoConnectModel.ArduinoConnect();
                Application.Run(new LoginForm());




            





        }

    }
    }
