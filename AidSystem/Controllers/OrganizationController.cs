using AidSystemDAL.Models;
using CharitySystemBLL.BLL;
using Microsoft.AspNetCore.Mvc;

namespace CharitySystem.Controllers
{
    public class OrganizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAllOrganizations()
        {
            OrganizationBLL organizationBLL = new OrganizationBLL();
            return View(organizationBLL.GetAll());
        }

        public IActionResult AddOrganization(
            string Name,
            string Address,
            string Activity,
            string CoverageOfAreas
            )
        {
            OrganizationBLL organizationBLL = new OrganizationBLL();
            {
                if (Name != null)
                {
                    organizationBLL.Add(
                 Name,
                 Address,
                 Activity,
                 CoverageOfAreas);
                }
            }
            return View("AddOrganization");
        }

        [HttpGet]
        public IActionResult EditOrganization(int ID)
        {
            OrganizationBLL organizationBLL = new OrganizationBLL();
            Organization organization = organizationBLL.GetByID(ID);
            if (organization == null)
            {
                return NotFound();
            }
            else
            {
                return View(organization);
            }
        }

        [HttpPost]
        public IActionResult EditOrganization(
            int ID,
            string Name,
            string Address,
            string Activity,
            string CoverageOfAreas)
        {

            if (Name == null)
            {
                return ViewBag.Error = "Organization not exist";
            }
            else
            {
                OrganizationBLL organizationBLL = new OrganizationBLL();
                organizationBLL.Update(
                    ID,
                    Name,
                    Address,
                    Activity,
                    CoverageOfAreas);
            }
            return RedirectToAction("ViewAllOrganizations", "Organization");
        }

        public IActionResult Delete(int ID)
        {
            OrganizationBLL organization = new OrganizationBLL();
            organization.DeleteOrganization(ID);

            return RedirectToAction("Dashboard", "Dashboard");
        }
    }
}
