using Core.Entities.Base;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _contex;
        private readonly DbSet<T> _dbTable;
        public Repository(AppDbContext context)
        {
            _contex = context;
            _dbTable = _contex.Set<T> ();     
        }
        public T Get(int id)
        {
            return _dbTable.Find(id);
        }

        public List<T> GetAll()
        {
            return _dbTable.ToList ();
        }
        public void Add(T item)
        {
            item.CreatedAt = DateTime.Now;
           _dbTable.Add (item);
        }
        public void Update(T item)
        {
            item.ModifiedAt = DateTime.Now;
          _dbTable.Update (item);
        }
        public void Delete(T item)
        {
           _dbTable.Remove (item);
        }
        
    }
}
