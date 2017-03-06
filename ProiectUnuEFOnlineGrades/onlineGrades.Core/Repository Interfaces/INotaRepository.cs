using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;

namespace onlineGrades.Core.Repository_Interfaces
{
    public interface INotaRepository:IGenericRepository<Nota>
    {
        Nota getNotaById(Guid id);
        void inserNewNota(Nota nota);
    }
}
