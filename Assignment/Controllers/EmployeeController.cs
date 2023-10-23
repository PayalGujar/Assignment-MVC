using Microsoft.AspNetCore.Mvc;
using Assignment.Models;


namespace Assignment.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDLA db;
        IConfiguration configuration;

        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new EmployeeDLA(this.configuration);
        }
        public IActionResult Index()
        {
            return View(db.GetEmployee());
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee e1)
        {
            try
            {
                int result = db.AddEmployee(e1);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));//List 
                }
                else
                {
                    return View();//remain on create pages
                }

            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
