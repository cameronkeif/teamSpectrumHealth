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
    /// Used to select entries in the PENDING_SHORTAGES table
    /// </summary>
    public class LoginRepository
    {
        private LoginDBContext db;

        public LoginRepository()
        {
            this.db = new LoginDBContext();
        }

        public LoginRepository(LoginDBContext dbContext)
        {
            this.db = dbContext;
        }

        /// <summary>
        /// Gets every entry in USER
        /// </summary>
        /// <returns>An array containing all of the entries in USER</returns>
        public virtual Login[] GetAllLogins()
        {
            List<Login> logins = new List<Login>();

            foreach (Login login in db.Logins.ToList())
            {
                logins.Add(login);
            }

            return logins.ToArray();
        }

        public bool CheckLogin(Login login)
        {
            if (Authentication.Authenticated)
            {
                login.Type = Authentication.Type;
                login.Username = Authentication.Username;
                return true;
            }

            foreach (Login l in db.Logins.ToList())
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