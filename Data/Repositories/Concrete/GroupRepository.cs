using Core.Entities;
using Data.Contexts;
using Data.Repositories.Abstract;
using Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private readonly AppDbContext _context;

        public GroupRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Group GetByIdWithStudents(int id)
        {
            return _context.Groups.Include(x => x.Students).FirstOrDefault(x => x.Id == id);
        }
        public Group GetByName(string name)
        {
            return _context.Groups.FirstOrDefault(g => g.Name.ToLower() == name.ToLower());
        }
       
    }
}

