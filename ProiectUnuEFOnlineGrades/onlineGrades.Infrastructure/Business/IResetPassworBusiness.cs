﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;

namespace onlineGrades.Infrastructure.Business
{
    public interface IResetPassworBusiness
    {
        User getUser(string email, string tipCont);
        User verifyID(Guid id);
    }
}