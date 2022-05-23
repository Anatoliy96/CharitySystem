using AidSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharitySystemBLL.BLL.DTO
{
    public class MemberOrganizationDTO
    {
        public List<Organization> Organizations { get; set; }
        public Member Member { get; set; }
    }
}
