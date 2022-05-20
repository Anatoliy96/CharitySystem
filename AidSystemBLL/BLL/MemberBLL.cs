using AidSystemDAL.Contexts;
using AidSystemDAL.DAO.UnitsOfWork;
using AidSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemBLL.BLL
{
    public class MemberBLL
    {
        public List<Member> GetAll()
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            {
                return unitOfWork.Members.GetAll().ToList();
            }
        }

        public Member GetByID(int ID)
        {
            UnitOfWork unitOfWork=new UnitOfWork(new AidDbContext());
            {
                return unitOfWork.Members.Get(ID);
            }
        }

        public void Add(
            string FirstName,
            string SecondName,
            string LastName,
            int Code,
            int OrganizationID)
        {
            Member member = new Member();
            {
                member.FirstName = FirstName;
                member.SecondName = SecondName;
                member.LastName = LastName;
                member.Code = Code;
                member.AppointedDate = DateTime.Now;
                member.OrganizationID = OrganizationID;
            }

            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            unitOfWork.Members.Add(member);
        }

        public void Update(
            int ID,
            string FirstName,
            string SecondName,
            string LastName,
            int Code,
            int OrganizationID)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());

            Member member = new Member();
                
                member.ID = ID;
                member.FirstName = FirstName;
                member.SecondName = SecondName;
                member.LastName = LastName;
                member.Code = Code;
                member.OrganizationID = OrganizationID;
            

            unitOfWork.Members.Update(member);
        }

        public void DeleteMember(int ID)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            Member member = unitOfWork.Members.Get(ID);
            unitOfWork.Members.Remove(member);
        }
    }
}
