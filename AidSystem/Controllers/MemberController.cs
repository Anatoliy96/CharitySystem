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
        
        public IActionResult EditMember(int ID)
        {
            MemberBLL memberBLL = new MemberBLL();
            Member member = memberBLL.GetByID(ID);
            if (member == null)
            {
                return NotFound();
            }
            else
            {
                return View(member);
            }
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
                return RedirectToAction("ViewAllMembers", "Member");
        } 

    }
}
