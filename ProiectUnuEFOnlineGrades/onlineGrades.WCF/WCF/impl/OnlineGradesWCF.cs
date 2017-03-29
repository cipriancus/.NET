using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;
using onlineGrades.Infrastructure.Business;
using onlineGrades.Infrastructure.Business.impl;
using onlineGrades.Infrastructure.Repository;
using System.ServiceModel;
using System.Data.Entity;
using System.Runtime.Serialization;

namespace onlineGrades.Infrastructure.WCF.impl
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class OnlineGradesWCF : IOnlineGradesWCF
    {

        ILoginBusiness loginBusiness=new LoginBusiness(new StudentRepository(),new ProfesorRepository());

        IRegisterBusiness register = new RegisterBusiness(new StudentRepository(), new ProfesorRepository());

        User IOnlineGradesWCF.LoginUser(string username, string password)
        {
            User user = new User((User)loginBusiness.verifyLogin(username, password));
            return user;
        }


        bool IOnlineGradesWCF.confirmUser(Guid registerGuid)
        {
            try
            {
                register.confirmUser(registerGuid);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        bool IOnlineGradesWCF.editProfesor(Profesor profesor)
        {
            try
            {
                register.editProfesor(profesor);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        bool IOnlineGradesWCF.editStudent(Student student)
        {
            try
            {
                register.editStudent(student);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        bool IOnlineGradesWCF.registerProfesor(Profesor profesor)
        {
            try
            {
                register.registerProfesor(profesor);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        bool IOnlineGradesWCF.registerStudent(Student student)
        {
            try
            {
                register.registerStudent(student);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
