using LearnerProject.Models.Context;
using LearnerProject.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    [SessionTimeOut]
    public class AdminDashboardController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }
    }
}