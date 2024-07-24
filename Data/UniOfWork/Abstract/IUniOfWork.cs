using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UniOfWork.Abstract
{
    public interface IUniOfWork
    {
        void Commit();  
    }
}
