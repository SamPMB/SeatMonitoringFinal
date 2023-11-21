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

            try
            {
                LoginForm1 loginForm = new LoginForm1();
              
                Application.Run(loginForm);
            }   
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }



        }

    }
}
