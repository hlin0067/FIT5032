using FIT5032_MyCodeSnippet.HelloWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FIT5032_MyCodeSnippet.Models.Exercise.Student;

namespace FIT5032_MyCodeSnippet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            Hello hello = new Hello();
            // I assigned the ViewBag.Message to the result
            ExampleDictionary ed = new ExampleDictionary();
            ed.Example();
            ViewBag.Message = hello.GetHello();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}