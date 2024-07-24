using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Application.Services.Abstract
{
    public interface  IGroupService
    {
        void AddGroup();
        void DeleteGroup();
        void UpdateGroup();
        void GetAllGroups();
        void GetDetailsofGroup();
    }
}
