using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace Assignment.Controllers
{
    public class CourseController : Controller
    {       
            [HttpGet]

            public IActionResult CourseDetails()
            {
                List<string> Options = new List<string>()
            {
                "Java" , "C#" , "React" , "Angular" , "Software Testing"
            };

                ViewData["Options"] = new SelectList(Options);
                return View();
            }
            [HttpPost]
            public IActionResult CourseDetails(IFormCollection form)
            {
                
                ViewBag.Name = form["Name"];
                ViewBag.Gender = form["gender"];
                ViewBag.Options = form["Options"];
            ViewBag.course = form["course"];
                return View("DisplayCourseDetails");
            }
        }
    }
    
