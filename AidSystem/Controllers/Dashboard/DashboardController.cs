using Microsoft.AspNetCore.Mvc;

namespace CharitySystem.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            CharitySystemBLL.BLL.BLO.Dashboard.Dashboard dashboard = new CharitySystemBLL.BLL.BLO.Dashboard.Dashboard();
            return View(dashboard.GetViewModels());
            //return View();
        }
    }
}
