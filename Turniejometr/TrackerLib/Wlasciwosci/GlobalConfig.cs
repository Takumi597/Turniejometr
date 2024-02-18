using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using TrackerLib.Data;


namespace TrackerLib.Wlasciwosci
{
    public static class GlobalConfig
    {
        public const string NagrodyFile = "Nagrody.csv";
        public const string OsobyFile = "Osoby.csv";
        public const string DruzynyFile = "Druzyny.csv";
        public const string TurniejeFile = "Turnieje.csv";
        public const string MeczeFile = "Mecze.csv";
        public const string AktualneMeczeFile ="AktualneMecze.csv";

        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(DatabaseType DB)
        {

            

            
                TextConnector text = new TextConnector();
                Connection = text;
            

        }

        public static string CnnString(string name)

        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public static string AppKeyLookup(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
