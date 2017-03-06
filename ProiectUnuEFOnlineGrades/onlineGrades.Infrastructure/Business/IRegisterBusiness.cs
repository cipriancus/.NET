using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;

namespace onlineGrades.Infrastructure.Business
{
    public interface IRegisterBusiness
    {
        bool registerProfesor(Profesor profesor);
        bool registerStudent(Student student);
        bool confirmUser(Guid registerGuid);
        bool editProfesor(Profesor profesor);
        bool editStudent(Student student);
    }
}
