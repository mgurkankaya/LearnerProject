using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
            var values = context.Courses.Include(x => x.Reviews).OrderByDescending(x => x.CourseId).Take(3).ToList();
            return PartialView(values);
        }


        public ActionResult CourseDetail(int id )
        {
            var value = context.Courses.Find(id);
            var reviewList = context.Reviews.Where(x=>x.CourseId==id).ToList();
            ViewBag.review = reviewList;
            return View(value);
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