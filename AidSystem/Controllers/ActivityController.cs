using AidSystemDAL.Models;
using CharitySystemBLL.BLL;
using Microsoft.AspNetCore.Mvc;

namespace CharitySystem.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewAllActivities()
        {
            ActivityBLL activityBLL = new ActivityBLL();
            return View(activityBLL.GetAll());
        }

        public IActionResult AddActivity(
            string Name,
            DateTime Date,
            DateTime FromHour,
            DateTime ToHour,
            string Region,
            int UniqueCode)
        {
            ActivityBLL activityBLL = new ActivityBLL();
            {
                if (Name != null)
                {
                    activityBLL.Add(
                 Name,
                 Date,
                 FromHour,
                 ToHour,
                 Region,
                 UniqueCode);
                }
            }
            return View("AddActivity");
        }

        public IActionResult EditActivity(int ID)
        {
            ActivityBLL activityBLL = new ActivityBLL();
            Activity activity = activityBLL.GetByID(ID);
            if (activity == null)
            {
                return NotFound();
            }
            else
            {
                return View(activity);
            }
        }

        [HttpPost]
        public IActionResult EditActivity(
            int ID,
            string Name,
            DateTime Date,
            DateTime FromHour,
            DateTime ToHour,
            string Region,
            int UniqueCode)
        {

            if (Date.ToString() == null)
            {
                return ViewBag.Error = "Activity not exist";
            }
            else
            {
                ActivityBLL activityBLL = new ActivityBLL();
                activityBLL.Update(
                    ID,
                    Name,
                    Date,
                    FromHour,
                    ToHour,
                    Region,
                    UniqueCode);
            }
            return RedirectToAction("ViewAllActivities", "Activity");
        }

        public IActionResult Delete(int ID)
        {
            ActivityBLL activityBLL = new ActivityBLL();
            activityBLL.DeleteActivity(ID);

            return RedirectToAction("Index", "Home");
        }
    }
}
