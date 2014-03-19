//-----------------------------------------------------------------------
// <copyright file="LoginRepository.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using MedicationsShortagesDashboard.Models;

    /// <summary>
    /// Used to select entries in the USER table
    /// </summary>
    public class LoginRepository
    {
        /// <summary>
        /// Database context for login
        /// </summary>
        private LoginDBContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRepository"/> class
        /// </summary>
        public LoginRepository()
        {
            this.db = new LoginDBContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRepository"/> class using a database context
        /// </summary>
        /// <param name="db">The database context to initialize with</param>
        public LoginRepository(LoginDBContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Gets every entry in USER
        /// </summary>
        /// <returns>An array containing all of the entries in USER</returns>
        public virtual Login[] GetAllLogins()
        {
            List<Login> logins = new List<Login>();

            foreach (Login login in this.db.Logins.ToList())
            {
                logins.Add(login);
            }

            return logins.ToArray();
        }

        /// <summary>
        /// Returns single user
        /// </summary>
        /// <param name="user">Username to find</param>
        /// <returns>Login of requested user</returns>
        public Login GetLogin(string user)
        {
            return this.db.Logins.Find(user);
        }

        /// <summary>
        /// Check if a given login is valid
        /// </summary>
        /// <param name="login">The login to check</param>
        /// <returns>True if the login is valid</returns>
        public bool CheckLogin(Login login)
        {
            if (Authentication.Authenticated)
            {
                login.Type = Authentication.Type;
                login.Username = Authentication.Username;
                return true;
            }

            foreach (Login l in this.db.Logins.ToList())
            {
                if (l.Username == login.Username && l.Password == login.Password)
                {
                    Authentication.Authenticated = true;
                    login.Type = Authentication.Type = l.Type;
                    Authentication.Username = login.Username;
                    return true;
                }
            }

            return false;
        }
    }
}