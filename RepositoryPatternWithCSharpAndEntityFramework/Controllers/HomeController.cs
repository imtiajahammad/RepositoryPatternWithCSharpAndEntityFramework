using RepositoryPatternWithCSharpAndEntityFramework.DataLayer;
using RepositoryPatternWithCSharpAndEntityFramework.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryPatternWithCSharpAndEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {





            using(var unitOfWork=new UnitOfWork(new ApplicationDbContext()))
            {
                //Example1
                var course = unitOfWork.Courses.Get(1);


                //Example2
                var courses = unitOfWork.Courses.GetCourseWithAuthors(1,4);


                //Example3
                var author = unitOfWork.Authors.GetAuthorWithCourses(1);
                bool removeRange=unitOfWork.Courses.RemoveRange(author.Courses);
                bool remove = unitOfWork.Authors.Remove(author);
                bool res=unitOfWork.Complete();

            }









            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}