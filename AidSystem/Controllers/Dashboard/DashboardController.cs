using AidSystemBLL.BLL;
using CharitySystemBLL.BLL;
using CharitySystemBLL.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CharitySystem.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            CharitySystemBLL.BLL.BLO.Dashboard.Dashboard dashboard = new CharitySystemBLL.BLL.BLO.Dashboard.Dashboard();
            return View(dashboard.GetViewModels());
        }

        public IActionResult ViewAllMembers()
        {
            MemberBLL memberBLL = new MemberBLL();
            return View(memberBLL.GetAll());
        }

        [HttpGet]
        public IActionResult AddMember()
        {
            OrganizationBLL organizationBLL = new OrganizationBLL();
            MemberOrganizationDTO memberOrganizationDTO = new MemberOrganizationDTO();
            memberOrganizationDTO.Organizations = organizationBLL.GetAll().ToList();
            return View(memberOrganizationDTO);
        }

        [HttpPost]
        public IActionResult AddMember(
            string FirstName,
            string SecondName,
            string LastName,
            int Code,
            int OrganizationID)
        {
            MemberBLL member = new MemberBLL();
            {
                if (FirstName != null)
                {
                    member.Add(
                 FirstName,
                 SecondName,
                 LastName,
                 Code,
                 OrganizationID);
                }
            }
            return RedirectToAction("Dashboard", "Dashboard");
        }
    }
}
