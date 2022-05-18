using AidSystemDAL.Contexts;
using AidSystemDAL.DAO.Repositories;
using AidSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.DAO.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AidDbContext context;

        public UnitOfWork(AidDbContext _context)
        {
            context = _context;
            Members = new MemberRepository(context);
            Activities = new ActivityRepository(context);
            Organizations = new OrganizationRepository(context);
            MemberActivities = new MemberActivityRepository(context);
        }

        public IMemberRepository Members { get; private set; }
        public IActivityRepository Activities { get; private set; }
        public IOrganizationRepository Organizations { get; private set; }
        public IMemberActivityRepository MemberActivities { get; private set; }

        public int Complete()
        {
           return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
