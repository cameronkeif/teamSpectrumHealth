﻿//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class for a login 
    /// </summary>
    [Table("USER")]
    public class Login
    {
        /// <summary>
        /// User's username
        /// </summary>
        [Column("USERNAME")]
        private string username;

        /// <summary>
        /// User's password
        /// </summary>
        [Column("PASSWORD")]
        private string password;

        /// <summary>
        /// The type of user
        /// </summary>
        [Column("TYPE")]
        private string type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> 
        /// class.
        /// </summary>
        /// <param name="username">User's name</param>
        /// <param name="password">User's password</param>
        /// <param name="type">User's type</param>
        public Login(string username, string password, string type)
        {
            this.username = username;
            this.password = password;
            this.type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/>
        /// class without parameters
        /// </summary>
        public Login()
        {
            this.username = string.Empty;
            this.password = string.Empty;
            this.type = string.Empty;
        }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        [Key]
        [Column("USERNAME")]
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
            }
        }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        [Column("PASSWORD")]
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's type
        /// </summary>
        [Column("TYPE")]
        public string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        /// <summary>
        /// Checks if two logins are equal. Mostly used for unit testing.
        /// </summary>
        /// <param name="login">The other login checking equivalence against.</param>
        /// <returns>boolean indicating if the two logins are equal.</returns>
        public bool Equals(Login login)
        {
            return this.Username.Equals(login.Username) && this.password.Equals(login.Password) && this.type.Equals(login.Type);
        }
    }
}