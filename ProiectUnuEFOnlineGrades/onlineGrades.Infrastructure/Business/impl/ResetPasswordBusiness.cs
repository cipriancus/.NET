using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;
using onlineGrades.Core.Repository_Interfaces;

namespace onlineGrades.Infrastructure.Business.impl
{
    public class ResetPasswordBusiness : IResetPassworBusiness
    {

        private IProfesorRepository ProfesorRepository;
        private IStudentRepository StudentRepository;

        public ResetPasswordBusiness(IStudentRepository StudentRepository, IProfesorRepository ProfesorRepository)
        {
            this.StudentRepository = StudentRepository;
            this.ProfesorRepository = ProfesorRepository;
        }

        User IResetPassworBusiness.getUser(string email,string tipCont)
        {
            Profesor profesor = ProfesorRepository.getProfesorByEmail(email);
            Student student = StudentRepository.getStudentByEmail(email);

            if (student != null)
            {
                return student;
            }
            else if (profesor != null)
            {
                return profesor;
            }
            else
            {
                return null;
            }
        }

        User IResetPassworBusiness.verifyID(Guid id)
        {
            Profesor profesor = ProfesorRepository.getProfesorByResetUUID(id);
            Student student = StudentRepository.getStudentByResetUUID(id);

            if (student != null)
            {
                return student;
            }
            else if (profesor != null)
            {
                return profesor;
            }
            else
            {
                return null;
            }
        }
    }
}
