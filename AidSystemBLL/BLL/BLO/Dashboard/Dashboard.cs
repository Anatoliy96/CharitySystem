using AidSystemBLL.BLL;
using AidSystemDAL.Models.Authentication;
using CharitySystemBLL.BLL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharitySystemBLL.BLL.BLO.Dashboard
{
    public class Dashboard
    {
        private readonly UserManager<ApplicationUser> userManager;
        public ViewModel GetViewModels()
        {
            MemberBLL memberBLL = new MemberBLL();
            ActivityBLL activityBLL = new ActivityBLL();
            OrganizationBLL organizationBLL = new OrganizationBLL();
            ApplicationUser applicationUser = new ApplicationUser();
            return new ViewModel
            {
                MemberCount = memberBLL.GetAll().Count(),
                ActivityCount = activityBLL.GetAll().Count(),
                OrganizationCount = organizationBLL.GetAll().Count(),
                Members = memberBLL.GetAll().ToList().Take(10),
                Activities = activityBLL.GetAll().ToList().Take(10),
                Organizations = organizationBLL.GetAll().ToList().Take(10)
            };
        }
    }
}
