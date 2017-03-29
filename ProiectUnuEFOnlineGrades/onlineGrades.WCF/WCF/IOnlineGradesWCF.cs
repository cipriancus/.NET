using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;
using System.ServiceModel;
using System.Data.Entity;
using System.Runtime.Serialization;

namespace onlineGrades.Infrastructure.WCF
{
    [ServiceContract]
    public interface IOnlineGradesWCF
    {
        [OperationContract]
        User LoginUser(string username, string password);

        [OperationContract]
        bool registerProfesor(Profesor profesor);
        [OperationContract]
        bool registerStudent(Student student);
        [OperationContract]
        bool confirmUser(Guid registerGuid);
        [OperationContract]
        bool editProfesor(Profesor profesor);
        [OperationContract]
        bool editStudent(Student student);
    }
}
