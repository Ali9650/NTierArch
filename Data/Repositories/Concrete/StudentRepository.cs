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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
             private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Student GetByIdWithGroups(int id)
        {
            return _context.Students.Include(x => x.Group).FirstOrDefault(x => x.Id == id);
        }
        public Student GetByName(string name)
        {
            return _context.Students.FirstOrDefault(g => g.Name.ToLower() == name.ToLower());
        }
 
    }
    
}
