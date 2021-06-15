using System;

namespace Utilities
{
    public class Configuration
    {
        private static string _connectionString;
        private static int _companyID;
        private static int _userID;
        
        public static string ConnectionString { get => _connectionString; set => _connectionString = value; }
        public static int CompanyID { get => _companyID; set => _companyID = value; }
        public static int UserID { get => _userID; set => _userID = value; }
        
    }
}
