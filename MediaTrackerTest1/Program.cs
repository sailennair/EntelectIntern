using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    class Program



    {

        static readonly Container container;

        static Program()
        {
            // 1. Create a new Simple Injector container
            container = new Container();

            // 2. Configure the container (register)
            //container.RegisterInitializer<SeriesImplementation>(handlerToInitialize => {
            //    handlerToInitialize.episodeImplementation = new EpisodesImplementation();
            //});



            container.Register<ISeriesInterface, SeriesImplementation>();
            container.Register<IEpisodesInterface, EpisodesImplementation>();

            // 3. Verify your configuration
            container.Verify();
        }



        static void Main(string[] args)
        {
            IMovieService Movieservice = new MovieServiceImplementation();

            IBookInterface BookService = new BookServiceImplementation();

            IAppUser appUserService = new AppUserService();

            //ISeriesInterface seriesService = new SeriesImplementation();

            //IEpisodesInterface episodeService = new EpisodesImplementation();

            Model1 db = new Model1();


            //foreach (MovieTable movieTable in Movieservice.GetAll())
            //    Console.WriteLine(movieTable.MovieName);

            //Console.WriteLine("****************************");


            //Movieservice.Delete(6);

            //foreach (MovieTable movieTable in Movieservice.GetAll())
            //    Console.WriteLine(movieTable.MovieName);

            //Console.WriteLine("****************************");

            //MovieTable newMovieEntry = new MovieTable
            //{
            //    MovieName = "SpongeBob2"
            //};

            //Movieservice.Create(newMovieEntry);


            //foreach (MovieTable movieTable in Movieservice.GetAll())
            //    Console.WriteLine(movieTable.MovieName);

            //Console.WriteLine("****************************");






            //MovieTable CheckUpdateMovieEnrty = new MovieTable
            //{
            //    MovieID = 2,
            //    MovieName = "Iron Man 2"
            //};

            //Movieservice.Update(CheckUpdateMovieEnrty);


            //foreach (MovieTable movieTable in Movieservice.GetAll())
            //    Console.WriteLine(movieTable.MovieName);

            //Console.WriteLine("****************************");




            //int movieIDDelete = 4;

            //Movieservice.Delete(movieIDDelete);


            //foreach (MovieTable movieTable in Movieservice.GetAll())
            //    Console.WriteLine(movieTable.MovieName);


            ////////////////////////////////////////////Book Testing ///////////////////////////////////////
            //foreach (BookTable bookTable in BookService.GetAll())
            //    Console.WriteLine(bookTable.BookName);
            //Console.WriteLine("****************************");

            //BookTable NewBook = new BookTable
            //{
            //    BookName = "Life of Molefe"
            //};

            //BookService.Create(NewBook);

            //foreach (BookTable bookTable in BookService.GetAll())
            //    Console.WriteLine(bookTable.BookName);
            //Console.WriteLine("****************************");




            //BookService.Delete(5);

            //foreach (BookTable bookTable in BookService.GetAll())
            //    Console.WriteLine(bookTable.BookName);
            //Console.WriteLine("****************************");

            //Console.ReadLine();
            /////////////////////////////////////////////////////////////////////////////////////////////
            ////Testing the appuser implementation
            //            foreach (AppUserTable appTable in appUserService.GetAll())
            //                Console.WriteLine(appTable.Username);
            //            Console.WriteLine("****************************");


            //            appUserService.Delete(1);


            //            foreach (AppUserTable appTable in appUserService.GetAll())
            //                Console.WriteLine(appTable.Username);
            //            Console.WriteLine("****************************");
            //////////////////////////////////////////////////////////////////////////////////////////////////////

            ISeriesInterface x = container.GetInstance<ISeriesInterface>();
            foreach (SeriesTable seriesTable in x.GetAll())
                Console.WriteLine(seriesTable.SeriesName);
            Console.WriteLine("****************************");


            //SeriesTable newSeries = new SeriesTable
            //{
            //    SeriesName = "Big Bang Theory"
            //};


            //seriesService.Create(newSeries);


            //EpisodesTable newEpisode = new EpisodesTable
            //{
            //    Season = 3,
            //    SeriesID = 1


            //};
           

            //episodeService.Create(newEpisode);


            x.Delete(1);

            foreach (SeriesTable seriesTable in x.GetAll())
                Console.WriteLine(seriesTable.SeriesName);
            Console.WriteLine("****************************");

            //Console.WriteLine(Movieservice.GetAll());
            /////////////////////////////////////////////////////////////////////////////
            //int userID = 4;



            //var episodeList = db.SeriesTransitionTables.Where(x => x.UserID == userID)
            //    .Select(x => x.EpisodesTable)
            //    .Select(x => x.SeriesTable)
            //    .Select(x => x.SeriesName)
            //    .Distinct()
            //    .ToList();

            //var test = (from u in db.AppUserTables
            //           join st in db.SeriesTransitionTables on u.UserID equals st.UserID
            //           join ep in db.EpisodesTables on st.EpisodesID equals ep.EpisodesID
            //           join s in db.SeriesTables on ep.SeriesID equals s.SeriesID
            //           select new { s.SeriesName, u.Username }).Distinct().ToList();

            //var test2 = (from u in db.AppUserTables
            //           from st in db.SeriesTransitionTables.Where(x => x.UserID == u.UserID && !x.isDeleted)
            //           from ep in db.EpisodesTables.Where(x => x.EpisodesID == st.EpisodesID)
            //           from s in db.SeriesTables.Where(x => x.SeriesID == ep.SeriesID)
            //           select new { s.SeriesName, u.Username }).Distinct().ToList();




            //test.ForEach(x => Console.WriteLine(x));

            Console.ReadLine();







        }

    }
    }

