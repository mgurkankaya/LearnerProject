﻿using LearnerProject.Models.Class;
using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CourseVideoController : Controller
    {
        LearnerContext context = new LearnerContext();
        IEClass ie = new IEClass();
        public ActionResult Index()
        {

            var values = context.CourseVideos.ToList();
            return View(values);
        }
    }
}