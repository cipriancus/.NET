using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;
using onlineGrades.Core.Repository_Interfaces;

namespace onlineGrades.Infrastructure.Business.impl
{
    public class RegisterBusiness : IRegisterBusiness
    {
        private IStudentRepository StudentRepository;
        private IProfesorRepository ProfesorRepository;

        public RegisterBusiness(IStudentRepository StudentRepository, IProfesorRepository ProfesorRepository)
        {
            this.StudentRepository = StudentRepository;
            this.ProfesorRepository = ProfesorRepository;
        }

        bool IRegisterBusiness.registerProfesor(Profesor profesor)
        {
            Profesor existent = ProfesorRepository.getProfesorByUsername(profesor.Username);

            if (existent != null)
                throw new Exception("Professor username already exists");

            profesor.Password = Cryptography.Sha256Password(profesor.Password);
            ProfesorRepository.insertNewProfesor(profesor);
            return true;
        }

        bool IRegisterBusiness.registerStudent(Student student)
        {
            Student existent = StudentRepository.getStudentByUsername(student.Username);

            if (existent != null)
                throw new Exception("Student username already exists");

            student.Password = Cryptography.Sha256Password(student.Password);
            StudentRepository.insertNewStudent(student);
            return true;
        }

        bool IRegisterBusiness.confirmUser(Guid registerGuid)
        {
            Student student = StudentRepository.getStudentByRegisterUUID(registerGuid);
            Profesor profesor = ProfesorRepository.getProfesorByRegisterUUID(registerGuid);
            if (student != null && student.isActive==false)
            {
                student.isActive = true;
                StudentRepository.Edit(student);
                StudentRepository.Save();
                return true;
            }
            else if (profesor != null && profesor.isActive == false)
            {
                profesor.isActive = true;
                ProfesorRepository.Edit(profesor);
                ProfesorRepository.Save();
                return true;
            }
            return false;
        }

        bool IRegisterBusiness.editProfesor(Profesor profesor)
        {
            ProfesorRepository.Edit(profesor);
            ProfesorRepository.Save();
            return true;
        }

        bool IRegisterBusiness.editStudent(Student student)
        {
            StudentRepository.Edit(student);
            StudentRepository.Save();
            return true;
        }
    }
}
