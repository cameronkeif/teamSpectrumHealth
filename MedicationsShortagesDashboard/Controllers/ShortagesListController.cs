//-----------------------------------------------------------------------
// <copyright file="ShortagesListController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;

    /// <summary>
    /// Controller for displaying all pending shortages
    /// </summary>
    public class ShortagesListController : BaseController
    {

        public ActionResult Create()
        {
            return this.View();
        }
    }
}
