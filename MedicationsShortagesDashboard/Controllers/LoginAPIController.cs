//-----------------------------------------------------------------------
// <copyright file="LoginAPIController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;

    /// <summary>
    /// Class allowing the view to interact with the API
    /// </summary>
    public class LoginAPIController : ApiController
    {
        /// <summary>
        /// Allows access to the database
        /// </summary>
        private LoginRepository loginRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginAPIController"/> class
        /// </summary>
        public LoginAPIController()
        {
            this.loginRepo = new LoginRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginAPIController"/> class using an existing repo
        /// </summary>
        /// <param name="loginRepo">The repo to initialize with</param>
        public LoginAPIController(LoginRepository loginRepo)
        {
            this.loginRepo = loginRepo;
        }

        /// <summary>
        /// Gets the loginRepo
        /// </summary>
        public LoginRepository LoginRepo
        {
            get
            {
                return this.loginRepo;
            }
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <returns>All entries in the login table</returns>
        public Login[] Get()
        {
            return this.loginRepo.GetAllLogins();
        }

        /// <summary>
        /// HTTP Post
        /// </summary>
        /// <param name="login">The login information to check</param>
        /// <returns>A http response indicating whether or not the login was successful</returns>
        public HttpResponseMessage Post(Login login)
        {
            if (this.loginRepo.CheckLogin(login))
            {
                return Request.CreateResponse<Login>(System.Net.HttpStatusCode.Accepted, login);
            }

            return Request.CreateResponse<Login>(System.Net.HttpStatusCode.BadRequest, login);
        }
    }
}
