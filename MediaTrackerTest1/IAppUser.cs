using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
 public   interface IAppUser
    {

        IEnumerable<AppUserTable> GetAll();

        void Create(AppUserTable appUserTable);

        void Update(AppUserTable appUserTable);

        void Delete(int appUserID);

        AppUserTable GetByID(int ID);

        bool checkUsernameAndPassword(string username, string password);

    }
}
