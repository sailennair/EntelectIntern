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
        public  IEnumerable<BookTransitionTable> GetUserBook(int userID)
        {
            var bookList = db.BookTransitionTables.Where(x => x.UserID == userID).ToList();
            return (bookList);
        }

    }
}
