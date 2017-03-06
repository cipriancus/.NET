using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;

namespace onlineGrades.Core.Repository_Interfaces
{
    public interface IProfesorRepository:IGenericRepository<Profesor>
    {
        Profesor getProfesorById(Guid id);
        Profesor getProfesorByUsername(string username);
        void insertNewProfesor(Profesor profesor);
        Profesor getProfesorByRegisterUUID(Guid id);
        Profesor getProfesorByEmail(string email);
        Profesor getProfesorByResetUUID(Guid id);
    }
}
