//-----------------------------------------------------------------------
// <copyright file="Authentication.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System.Web;
    using System.Web.Caching;

    /// <summary>
    /// Class for storing static user information
    /// </summary>
    public class Authentication
    {

        /// <summary>
        /// Gets or sets a value indicating whether a user is authenticated
        /// </summary>
        public static bool Authenticated
        {
            get
            {
                object auth = HttpContext.Current.Cache["Authenticated"];
                if (auth != null && (bool)auth != false) 
                {
                    return true;
                }

                return false;
            }

            set
            {
                HttpContext.Current.Cache["Authenticated"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's type
        /// </summary>
        public static string Type
        {
            get
            {
                if (HttpContext.Current.Cache["Type"] != null)
                {
                    return (string)HttpContext.Current.Cache["Type"];
                }
                return string.Empty;
            }

            set
            {
                HttpContext.Current.Cache["Type"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's username
        /// </summary>
        public static string Username
        {
            get
            {
                if (HttpContext.Current.Cache["Username"] != null)
                {
                    return (string)HttpContext.Current.Cache["Username"];
                }
                return "Guest";
            }

            set
            {
                HttpContext.Current.Cache["Username"] = value;
            }
        }

        /// <summary>
        /// Reset to the default state
        /// </summary>
        public static void Reset()
        {
            Authentication.Authenticated = false;
            Authentication.Username = "Guest";
            Authentication.Type = string.Empty;
        }
    }
}