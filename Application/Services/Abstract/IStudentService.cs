using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface  IStudentService
    {
        void AddStudent();
        void UpdateStudent();
        void DeleteStudent();
        void GetAllStudents();
        void GetDetailsofStudent();
    }
}
