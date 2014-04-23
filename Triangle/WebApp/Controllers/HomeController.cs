using Business.Business;
using DataAccess.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITriangleBusiness triangleBusiness;
        public HomeController(ITriangleBusiness triangleBusiness)
        {
            this.triangleBusiness = triangleBusiness;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TriangleModel triangleModel)
        {
            var triangleType = triangleBusiness.CheckTriangle(triangleModel.SideA, triangleModel.SideB, triangleModel.SideC);
            ViewBag.TypeTriangle = triangleType;
            return View(triangleModel);
        }
       
    }
}
