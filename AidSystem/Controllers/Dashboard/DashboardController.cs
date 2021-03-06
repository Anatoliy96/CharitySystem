using AidSystemBLL.BLL;
using AidSystemDAL.Models;
using CharitySystemBLL.BLL;
using CharitySystemBLL.BLL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharitySystem.Controllers.Dashboard
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
                CharitySystemBLL.BLL.BLO.Dashboard.Dashboard dashboard = new CharitySystemBLL.BLL.BLO.Dashboard.Dashboard();
                return View(dashboard.GetViewModels());
        }
    }
}

