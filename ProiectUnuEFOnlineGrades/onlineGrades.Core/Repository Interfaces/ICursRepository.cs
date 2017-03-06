using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;

namespace onlineGrades.Core.Repository_Interfaces
{
    public interface ICursRepository:IGenericRepository<Curs>
    {
        Curs getCursById(Guid id);
        void InsertNewCurs(Curs curs);
    }
}
