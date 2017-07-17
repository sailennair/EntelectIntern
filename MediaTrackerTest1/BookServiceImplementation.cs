using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
   public class BookServiceImplementation : GenericService<BookTable>,IBookInterface
    {
        public override void Update(BookTable updated, int key)
        {
            BookTable book= GetByID(key);

            if (book != null)
            {
                book.BookName = updated.BookName;
                db.SaveChanges();
            }
        }

        public string GetBookIcon(int UserID)
        {
            BookTable book = GetByID(UserID);
            if (book != null)
            {
                return book.BookIcon;

            }
            else return null;

        }

    }
}

    //    private Model1 db;



    //    public BookServiceImplementation()
    //    {
    //        db = new Model1();
    //    }

    //    public IEnumerable<BookTable> GetAll()
    //    {


    //        var Q3 = db.BookTabels.Where(mov => mov.isDeleted == false);

    //        return Q3.ToList();

    //    }


    //    public void Create(BookTable bookTable)
    //    {
    //        db.BookTabels.Add(bookTable);
    //        db.SaveChanges();

    //    }





    //    public void Update(BookTable bookTable)
    //    {
    //        int bookID = bookTable.BookID;

    //        var updateQ = db.BookTabels.SingleOrDefault(book => book.BookID == bookID);
    //        if (updateQ != null)
    //        {
    //            updateQ.BookName = bookTable.BookName;
    //            db.SaveChanges();
    //        }
    //    }



    //    public void Delete(int bookID)
    //    {

    //        var deleteQ = db.BookTabels.SingleOrDefault(book => book.BookID == bookID); //

    //        if (deleteQ != null)
    //        {
    //            deleteQ.isDeleted = true;
    //            deleteQ.BookTransitionTables.ToList().ForEach(x => x.isDeleted = true);
    //            db.SaveChanges();

    //        }
        


    //    }

            


    //    }


    //}

