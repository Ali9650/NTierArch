using Core.Entities;
using Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface IGroupRepository : IRepository<Group>
    {
        Group GetByName(string name);
        Group GetByIdWithStudents(int id);

    }
}
