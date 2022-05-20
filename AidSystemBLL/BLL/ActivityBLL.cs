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
    public class ActivityBLL
    {
        public List<Activity> GetAll()
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            {
                return unitOfWork.Activities.GetAll().ToList();
            }
        }

        public Activity GetByID(int ID)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            {
                return unitOfWork.Activities.Get(ID);
            }
        }
        public void Add(
            string Name,
            DateTime Date,
            DateTime FromHour,
            DateTime ToHour,
            string Region,
            int UniqueCode)
        {
            Activity activity = new Activity();
            {
                activity.Name = Name;
                activity.Date = Date;
                activity.FromHour = FromHour;
                activity.ToHour = ToHour;
                activity.Region = Region;
                activity.UniqueCode = UniqueCode;
            }

            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            unitOfWork.Activities.Add(activity);
        }
        public void Update(
            int ID,
            string Name,
            DateTime Date,
            DateTime FromHour,
            DateTime ToHour,
            string Region,
            int UniqueCode)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());

            Activity activity = new Activity();

            activity.ID = ID;
            activity.Name = Name;
            activity.Date = Date;
            activity.FromHour = FromHour;
            activity.ToHour = ToHour;
            activity.Region = Region;
            activity.UniqueCode = UniqueCode;


            unitOfWork.Activities.Update(activity);
        }

        public void DeleteActivity(int ID)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AidDbContext());
            Activity activity = unitOfWork.Activities.Get(ID);
            unitOfWork.Activities.Remove(activity);
        }
    }
}
