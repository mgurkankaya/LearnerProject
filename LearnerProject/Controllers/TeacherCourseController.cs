using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class TeacherCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            string name = Session["TeacherName"].ToString();
            var values = context.Courses.Where(x=>x.Teacher.NameSurname == name).ToList();
            return View(values);
        }

        public ActionResult DeleteCourse(int id) 
        {
            var values = context.Courses.Find(id);
            context.Courses.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCourse()
        {

            var categories = context.Categories.Where(x => x.Status == true).ToList();


            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();

            ViewBag.category = categoryList;
            return View();

        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            string name = Session["TeacherName"].ToString();
            course.TeacherId=context.Teachers.Where(x=>x.NameSurname == name).Select(x=>x.TeacherId).FirstOrDefault();
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            var categories = context.Categories.Where(x => x.Status == true).ToList();


            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();

            ViewBag.category = categoryList;

            var value = context.Courses.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var value = context.Courses.Find(course.CourseId);
            string name = Session["TeacherName"].ToString();
            value.TeacherId = context.Teachers.Where(x => x.NameSurname == name).Select(x => x.TeacherId).FirstOrDefault();
            value.CourseName = course.CourseName;
            value.ImageUrl = course.ImageUrl;
            value.Description = course.Description;
            value.Price = course.Price;
            value.CategoryId = course.CategoryId;


            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}