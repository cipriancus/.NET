using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Repository_Interfaces.Generic_Repository;
using onlineGrades.Core.Entity;
using System.Data.Entity;
using onlineGrades.Core.Configuration.EF_Configuration;
using onlineGrades.Core.Repository_Interfaces;

namespace onlineGrades.Infrastructure.Repository
{
    //testat merge bine
    public class ProfesorRepository: GenericRepositoryAbstract<DataBaseManagement, Profesor>,IProfesorRepository
    {
        public override void Add(Profesor entity)
        {
            _entities.Profesori.Add(entity);
        }


        Profesor IProfesorRepository.getProfesorById(Guid id)
        {
            return FindBy(e => e.ProfesorId == id).FirstOrDefault();
        }

        Profesor IProfesorRepository.getProfesorByUsername(string username)
        {
            return FindBy(e => e.Username == username).FirstOrDefault();
        }

        Profesor IProfesorRepository.getProfesorByRegisterUUID(Guid id)
        {
            return FindBy(e => e.RegisterUUID == id).FirstOrDefault();
        }

        void IProfesorRepository.insertNewProfesor(Profesor profesor)
        {
            Add(profesor);
            Save();
        }

        Profesor IProfesorRepository.getProfesorByEmail(string email)
        {
            return FindBy(e => e.Email == email).FirstOrDefault();
        }

        Profesor IProfesorRepository.getProfesorByResetUUID(Guid id)
        {
            return FindBy(e => e.ResetUUID == id).FirstOrDefault();
        }
    }
}
