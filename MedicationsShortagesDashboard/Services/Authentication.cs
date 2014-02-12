//-----------------------------------------------------------------------
// <copyright file="Authentication.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Class for storing static user information
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Indicates whether or not a user is authenticated
        /// </summary>
        private static bool authenticated = false;

        /// <summary>
        /// If authenticated, gives the user type
        /// </summary>
        private static string type = string.Empty;

        /// <summary>
        /// Gives the authenticated user's username
        /// </summary>
        private static string username = "Guest";

        /// <summary>
        /// Gets or sets a value indicating whether a user is authenticated
        /// </summary>
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

        /// <summary>
        /// Gets or sets the user's type
        /// </summary>
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

        /// <summary>
        /// Gets or sets the user's username
        /// </summary>
        public static string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }
    }
}