using AidSystemDAL.DAO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.DAO.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IActivityRepository Activities { get; }
        IMemberActivityRepository MemberActivities { get; }
        IOrganizationRepository Organizations { get; }
        IMemberRepository Members { get; }
        int Complete();
    }
}
