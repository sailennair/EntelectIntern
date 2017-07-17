using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    public class BookTransitionImplementation : IBookTransitionInterface
    {

        public Model1 db { get; set; }

        public BookTransitionImplementation()
        {
            db = new Model1();
        }

        public IEnumerable<BookTransitionTable> GetUserBook(int userID)
        {
            var bookList = db.BookTransitionTables.Where(x => x.UserID == userID).ToList();
            return (bookList);
        }

        public void UpdatestatusToRead(int BookID, int userID)
        {
            BookTransitionTable bookList = db.BookTransitionTables.Where(x => x.UserID == userID).Where(x => x.BookID == BookID).Single();
            bookList.StatusID = 2;
            db.SaveChanges();

        }

        public void UpdatestatusToBusyReading(int BookID, int userID)
        {
            BookTransitionTable bookList = db.BookTransitionTables.Where(x => x.UserID == userID).Where(x => x.BookID == BookID).Single();
            bookList.StatusID = 3;
            db.SaveChanges();
        }

        public void UpdatestatusToHaveNotRead(int BookID, int userID)
        {
            BookTransitionTable bookList = db.BookTransitionTables.Where(x => x.UserID == userID).Where(x => x.BookID == BookID).Single();
            bookList.StatusID = 1;
            db.SaveChanges();
        }


        public void addNew(int BookID, int userID)
        {
            BookTransitionTable newElement = new BookTransitionTable();
            newElement.BookID = BookID;
            newElement.StatusID = 1;
            newElement.UserID = userID;
            newElement.Read = true;

            db.BookTransitionTables.Add(newElement);
            db.SaveChanges();

        }

        public void UpdateStatus(int BookID, int userID, int Status)
        {
            BookTransitionTable bookList = db.BookTransitionTables.Where(x => x.UserID == userID).Where(x => x.BookID == BookID).Single();
            bookList.StatusID = Status;
            db.SaveChanges();
        }

    }



}

