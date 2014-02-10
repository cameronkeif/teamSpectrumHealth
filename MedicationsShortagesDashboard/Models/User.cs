//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Class for a user. WILL EVENTUALLY BE REPLACED BY ACTIVE DIRECTORY
    /// </summary>
    [Table("USER")]
    public class User
    {
        /// <summary>
        /// User's login 
        /// </summary>
        [Column("USERNAME")]
        private string username;

        /// <summary>
        /// User's password
        /// </summary>
        [Column("PASSWORD")]
        private string password;

        /// <summary>
        /// User type
        /// </summary>
        [Column("TYPE")]
        private string type;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> 
        /// class.
        /// </summary>
        /// <param name="name">User's login</param>
        /// <param name="source">User's password</param>
        /// <param name="type">User type</param>
        public User(string username, string password, string type)
        {
            this.username = username;
            this.password = password;
            this.type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/>
        /// class without parameters
        /// </summary>
        public User()
        {
            this.username = string.Empty;
            this.password = string.Empty;
            this.type = string.Empty;
        }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
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
        [Key]
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
        /// Gets or sets the type
        /// </summary>
        [Key]
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
        /// Checks if a given username/password combination is valid
        /// </summary>
        /// <param name="username">The username to check</param>
        /// <param name="password">Password to check</param>
        /// <returns>True if user exists and password matches</returns>
        public bool IsValid(string username, string password)
        {
            /*** THIS WILL BE HANDLED RESTFULLY ***/
            using (var cn = new SqlConnection(@"Data Source=35.9.22.107;Initial Catalog=WIN-FXS1E7PQTRU;Persist Security Info=True;User ID=Spectrum;Password=spectrum"))
            {
                string _sql = @"SELECT [Username] FROM [dbo].[USER] " +
                       @"WHERE [USERNAME] = @u AND [PASSWORD] = @p";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = username;
                cmd.Parameters
                    .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                    .Value = password;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }
    }
}