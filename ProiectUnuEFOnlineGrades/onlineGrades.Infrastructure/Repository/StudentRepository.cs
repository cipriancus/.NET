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
    //testat ok
    public class StudentRepository: GenericRepositoryAbstract<DataBaseManagement, Student>,IStudentRepository
    {
        public override void Add(Student entity)
        {
            _entities.Studenti.Add(entity);
        }


        Student IStudentRepository.getStudentByEmail(string email)
        {
            return FindBy(e => e.Email == email).FirstOrDefault();
        }

        Student IStudentRepository.getStudentById(Guid id)
        {
            return FindBy(e => e.StudentId == id).FirstOrDefault();
        }

        Student IStudentRepository.getStudentByRegisterUUID(Guid id)
        {
            return FindBy(e => e.RegisterUUID == id).FirstOrDefault();
        }

        Student IStudentRepository.getStudentByResetUUID(Guid id)
        {
            return FindBy(e => e.ResetUUID == id).FirstOrDefault();
        }

        Student IStudentRepository.getStudentByUsername(string Username)
        {
            return FindBy(e => e.Username == Username).FirstOrDefault();
        }

        void IStudentRepository.insertNewStudent(Student student)
        {
            Add(student);
            Save();
        }
    }
}
