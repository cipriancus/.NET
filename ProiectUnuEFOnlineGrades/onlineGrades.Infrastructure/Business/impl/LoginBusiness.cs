using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;
using onlineGrades.Core.Repository_Interfaces;

namespace onlineGrades.Infrastructure.Business.impl
{
    public class LoginBusiness : ILoginBusiness
    {
        private IProfesorRepository ProfesorRepository;
        private IStudentRepository StudentRepository;

        public LoginBusiness(IStudentRepository StudentRepository, IProfesorRepository ProfesorRepository)
        {
            this.StudentRepository = StudentRepository;
            this.ProfesorRepository = ProfesorRepository;
        }
        object ILoginBusiness.verifyLogin(string username, string password)
        {
            Profesor profesor = ProfesorRepository.getProfesorByUsername(username);
            Student student = StudentRepository.getStudentByUsername(username);

            if (student != null)
            {
                return (student.Password == Cryptography.Sha256Password(password)&&student.isActive==true ? (object)student : null);
            }else if(profesor!=null)
            {
                return (profesor.Password == Cryptography.Sha256Password(password)&&profesor.isActive==true ? (object)profesor : null);
            }
            else
            {
                return null;
            }
        }
    }
}
