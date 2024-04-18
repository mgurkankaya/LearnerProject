using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    [AllowAnonymous]
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
        public PartialViewResult DefaultClassroomPartial()
        {
            var values = context.Classrooms.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultCoursePartial()
        {
            var values = context.Courses.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultAboutPartial()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultFAQPartial()
        {
            var values = context.FAQs.ToList();
            return PartialView(values);
        }
    }
}