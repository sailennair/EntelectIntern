﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    interface IAppUser
    {

        IEnumerable<AppUserTable> GetAll();

        void Create(AppUserTable appUserTable);

        void Update(AppUserTable appUserTable);

        void Delete(int appUserID);

    }
}
