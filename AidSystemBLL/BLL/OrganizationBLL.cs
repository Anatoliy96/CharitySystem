using AidSystemDAL.Contexts;
using AidSystemDAL.DAO.UnitsOfWork;
using AidSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharitySystemBLL.BLL
{
    public class OrganizationBLL
    {
        public List<Organization> GetAll()
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            return unitOfWork.Organizations.GetAll().ToList();
        }

        public Organization GetByID(int ID)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            {
                return unitOfWork.Organizations.Get(ID);
            }
        }

        public void Add(
            string Name,
            string Address,
            string Activity,
            string CoverageOfAreas
            )
        {
            Organization organization = new Organization();
            {
                organization.Name = Name;
                organization.Address = Address;
                organization.Activity = Activity;
                organization.CoverageOfAreas = CoverageOfAreas;
            }

            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            unitOfWork.Organizations.Add(organization);
        }

        public void Update(
            int ID,
            string Name,
            string Address,
            string Activity,
            string CoverageOfAreas
            )
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());

            Organization organization = new Organization();

            organization.Name = Name;
            organization.Address = Address;
            organization.Activity = Activity;
            organization.CoverageOfAreas = CoverageOfAreas;


            unitOfWork.Organizations.Update(organization);
        }

        public void DeleteOrganization(int ID)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            Organization organization = unitOfWork.Organizations.Get(ID);
            unitOfWork.Organizations.Remove(organization);
        }
    }
}
