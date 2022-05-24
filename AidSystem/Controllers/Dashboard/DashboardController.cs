using AidSystemBLL.BLL;
using AidSystemDAL.Models;
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

       [HttpGet]
        public IActionResult EditMember(int ID)
        {
            MemberBLL memberBLL = new MemberBLL();
            OrganizationBLL organizationBLL = new OrganizationBLL();
            MemberOrganizationDTO memberOrganizationDTO = new MemberOrganizationDTO();
            memberOrganizationDTO.Member = memberBLL.GetByID(ID);
            memberOrganizationDTO.Organizations = organizationBLL.GetAll().ToList();
            return View(memberOrganizationDTO);
        }

        [HttpPost]
        public IActionResult EditMember(
            int ID,
            string FirstName,
            string SecondName,
            string LastName,
            int Code,
            int OrganizationID)
        {

            if (FirstName == null)
            {
                return ViewBag.Error = "Member don't exist";
            }
            else
            {
                MemberBLL memberBLL = new MemberBLL();
                memberBLL.Update(
                    ID,
                    FirstName,
                    SecondName,
                    LastName,
                    Code,
                    OrganizationID);
            }
            return RedirectToAction("ViewAllMembers", "Dashboard");
        }

        public IActionResult Delete(int ID)
        {
            MemberBLL memberBLL = new MemberBLL();
            memberBLL.DeleteMember(ID);

            return RedirectToAction("Dashboard", "Dashboard");
        }
    }
}

