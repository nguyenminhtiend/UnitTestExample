using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ReportController : Controller
    {
        private IReportingTriangle reportingTriangle;
        //
        // GET: /Report/
        public ReportController(IReportingTriangle reportingTriangle)
        {
            this.reportingTriangle = reportingTriangle;
        }

        public ActionResult Index()
        {
            return View(reportingTriangle.GetAllTriangle());
        }

    }
}
