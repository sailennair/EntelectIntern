using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    public class AppUserService : IAppUser
    {


        private Model1 db;


        public AppUserService()
        {
            db = new Model1();
        }


        public IEnumerable<AppUserTable> GetAll()
        {

            var Q3 = db.AppUserTables.Where(mov => mov.isDeleted == false);
            return Q3.ToList();
        }

        public void Create(AppUserTable appUserTable)
        {
            db.AppUserTables.Add(appUserTable);
            db.SaveChanges();

        }

        public void Update(AppUserTable appUserTable)
        {
            int appUserID = appUserTable.UserID;
            var updateQ = db.AppUserTables.SingleOrDefault(user => user.UserID == appUserID);
            if (updateQ != null)
            {
                updateQ.Username = appUserTable.Username;
                db.SaveChanges();
            }
        }
        public void Delete(int appUserID)
        {

            var deleteQ = db.AppUserTables.SingleOrDefault(x => x.UserID == appUserID);

            if (deleteQ != null)
            {
                deleteQ.isDeleted = true;
                //  deleteQ.BookTransitionTables.ToList().ForEach(x => x.isDeleted = true);
                deleteQ.MovieTransitionTables.ToList().ForEach(x => x.isDeleted = true);
                deleteQ.SeriesTransitionTables.ToList().ForEach(x => x.isDeleted = true);
                db.SaveChanges();
            }
        }

        public AppUserTable GetByID(int ID)
        {
            AppUserTable item = db.Set<AppUserTable>().Find(ID);

            return item;
        }


        public bool checkUsernameAndPassword(string username, string password)
        {



            //if (item == null)
            //{
            //    return false;
            //}
            //else if (password == item.Password)
            //{
            //    return true;
            //}
            return false;
        }
    }




}

