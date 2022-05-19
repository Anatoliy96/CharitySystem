using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.Models.Authentication
{
    public class UserRoles
    {
        public enum Roles{
            Admin,
            Member,
            User
        }
        public const Roles role = Roles.User;
    }
}
