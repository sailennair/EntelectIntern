using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    public class MovieTransitionImplementation : IMovieTransitionInterface
    {
        public Model1 db { get; set; }

        public MovieTransitionImplementation()
        {
            db = new Model1();
        }


        public IEnumerable<MovieTransitionTable> GetUserMovie(int userID)
        {
            var movieTransition = db.MovieTransitionTables.Where(x => x.UserID == userID).ToList();
            return movieTransition;
        }


        public void addNew(int MovieID, int userID)
        {
            MovieTransitionTable newElement = new MovieTransitionTable();
            newElement.MovieID = MovieID;
            newElement.StatusID = 1;
            newElement.UserID = userID;
            newElement.isDeleted = false;
            
            db.MovieTransitionTables.Add(newElement);
            db.SaveChanges();

        }


        public void UpdateStatus(int MovieID, int userID, int Status)
        {
            MovieTransitionTable movie = db.MovieTransitionTables.Where(x => x.UserID == userID).Where(x => x.MovieID == MovieID).Single();
            movie.StatusID = Status;
            db.SaveChanges();

        }





    }
}
