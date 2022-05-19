using AidSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.DAO
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        TEntity Get(int ID);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        //void DeleteAt(TEntity entity);
    }
}
