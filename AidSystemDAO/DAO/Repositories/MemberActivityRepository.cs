using AidSystemDAL.Contexts;
using AidSystemDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.DAO.Repositories
{
    public class MemberActivityRepository : Repository<MemberActivity>, IMemberActivityRepository
    {
        public MemberActivityRepository(AidDbContext context) 
            : base(context)
        {
        }

        public AidDbContext AidContext
        {
            get { return Context as AidDbContext; }
        }
    }
}
