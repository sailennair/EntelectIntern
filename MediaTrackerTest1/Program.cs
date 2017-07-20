using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTrackerTest1;

namespace MediaTrackerTest1
{
    class Program



    {

        static readonly Container container;

        static Program()
        {
            container = new Container();
            container.Register<ISeriesInterface, SeriesImplementation>();
            container.Register<IEpisodesInterface, EpisodesImplementation>();
            container.Verify();
        }



        static void Main(string[] args)
        {
            IMovieService Movieservice = new MovieServiceImplementation();
            IBookInterface BookService = new BookServiceImplementation();
            IAppUser appUserService = new AppUserService();

            Model1 db = new Model1();

            ISeriesInterface x = container.GetInstance<ISeriesInterface>();

            JwtTokenGeneration jwt = new JwtTokenGeneration();

            Console.WriteLine(jwt.GenerateToken(2));

            


            Console.ReadLine();







        }

    }
    }

