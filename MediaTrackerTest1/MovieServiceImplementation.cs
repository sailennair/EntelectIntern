using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    public class MovieServiceImplementation : GenericService<MovieTable>, IMovieService
    {
        public override void Update(MovieTable updated, int key)
        {
            MovieTable movie = GetByID(key);

            if (movie != null)
            {
                movie.MovieName = updated.MovieName;
                db.SaveChanges();
            }
        }

    }
}
