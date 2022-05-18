using AidSystemBLL.BLL;
using AidSystemDAL.Contexts;
using AidSystemDAL.DAO.UnitsOfWork;
using AidSystemDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AidSystem.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewAllMembers()
        {
            MemberBLL memberBLL = new MemberBLL();
            return View(memberBLL.GetAll());
        }

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
            return View("AddMember");
        }


    }
}
