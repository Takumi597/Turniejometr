using TrackerLib.Wlasciwosci;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            GlobalConfig.InitializeConnections(DatabaseType.TextFile);
            ApplicationConfiguration.Initialize();
            Application.Run(new StronaGlowna());
        }
    }
}