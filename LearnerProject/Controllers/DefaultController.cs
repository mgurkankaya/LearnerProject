using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class DefaultController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }

   public PartialViewResult DefaultBannerPartial()
        {
            var values = context.Banners.ToList();
            return PartialView(values);
        }


        public PartialViewResult DefaultCategoryPartial()
        {
            var values = context.Categories.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
    }
}