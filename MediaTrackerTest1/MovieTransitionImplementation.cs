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
    }
}
