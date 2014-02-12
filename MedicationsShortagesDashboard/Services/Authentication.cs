using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicationsShortagesDashboard.Services
{
    public class Authentication
    {
        private static bool authenticated = false;
        private static string type = "";

        public static bool Authenticated
        {
            get
            {
                return authenticated;
            }
            set
            {
                authenticated = value;
            }
        }

        public static string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
    }
}