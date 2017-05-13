using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;

namespace onlineGrades.Infrastructure.Business
{
    public interface IMailBusiness
    {
        void sendRegisterMail(User user);
        void sendResetMail(User user);

    }
}
