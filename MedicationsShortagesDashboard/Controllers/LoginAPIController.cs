using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicationsShortagesDashboard.Models;
using MedicationsShortagesDashboard.Services;

namespace MedicationsShortagesDashboard.Controllers
{
    public class LoginAPIController : ApiController
    {
        private LoginRepository loginRepo;

        public LoginAPIController()
        {
            this.loginRepo = new LoginRepository();
        }

        public Login[] Get()
        {
            return loginRepo.GetAllLogins();
        }

        public HttpResponseMessage Post(Login login)
        {
            if (this.loginRepo.CheckLogin(login))
            {
                return Request.CreateResponse<Login>(System.Net.HttpStatusCode.Created, login);
            }

            return null;
        }
    }
}
