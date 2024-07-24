using Abp.Domain.Uow;
using Core.Messages;
using Data.Contexts;
using Data.Repositories.Concrete;
using  Data.UniOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UniOfWork.Concrete
{

    public class UniOfWork : IUniOfWork
    {
        public readonly GroupRepository Groups;
        public readonly StudentRepository Students;
        private readonly AppDbContext _context;
        public UniOfWork()
        {
            _context=new AppDbContext();
            Groups = new GroupRepository(_context);
            Students = new StudentRepository(_context);
        }

        public void Commit()
        {
           try 
            { 
                _context.SaveChanges(); 
            } 
            catch (Exception)
            {
                Messages.ErrorOccuredMessage();
            }
        }
    }
}
