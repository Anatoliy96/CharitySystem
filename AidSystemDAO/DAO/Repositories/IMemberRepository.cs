using AidSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.DAO.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        public Member Details(int ID);
    }
}
