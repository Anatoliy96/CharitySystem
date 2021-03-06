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
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(AidDbContext context) 
            : base(context)
        {
        }

        public AidDbContext? AidContext
        {
            get { return Context as AidDbContext; }
        }
    }
}
