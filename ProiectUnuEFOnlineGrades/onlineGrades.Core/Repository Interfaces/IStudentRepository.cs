using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;

namespace onlineGrades.Core.Repository_Interfaces
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        Student getStudentById(Guid id);
        void insertNewStudent(Student student);
        Student getStudentByUsername(string Username);
        Student getStudentByRegisterUUID(Guid id);
        Student getStudentByEmail(string email);
        Student getStudentByResetUUID(Guid id);

    }
}
