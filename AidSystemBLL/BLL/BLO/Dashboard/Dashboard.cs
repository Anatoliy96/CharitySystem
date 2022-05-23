using AidSystemBLL.BLL;
using CharitySystemBLL.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharitySystemBLL.BLL.BLO.Dashboard
{
    public class Dashboard
    {
        public ViewModel GetViewModels()
        {
            MemberBLL memberBLL = new MemberBLL();
            ActivityBLL activityBLL = new ActivityBLL();
            return new ViewModel
            {
                MemberCount = memberBLL.GetAll().Count(),
                ActivityCount = activityBLL.GetAll().Count(),
                Members = memberBLL.GetAll().ToList(),
                Activities = activityBLL.GetAll().ToList()
            };
        }
    }
}
