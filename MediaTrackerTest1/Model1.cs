namespace MediaTrackerTest1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=MediaTrackerDB")
        {
        }

        public virtual DbSet<AppUserTable> AppUserTables { get; set; }
        public virtual DbSet<MovieTable> MovieTables { get; set; }
        public virtual DbSet<SeriesTable> SeriesTables { get; set; }
        public virtual DbSet<MovieTransitionTable> MovieTransitionTables { get; set; }
        public virtual DbSet<StatusTable> StatusTables { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<BookTable> BookTabels { get; set; }
        public virtual DbSet<BookTransitionTable> BookTransitionTables { get; set; }
        public virtual DbSet<SeriesTransitionTable> SeriesTransitionTables { get; set; }
        public virtual DbSet<EpisodesTable> EpisodesTables { get; set; }
        public virtual DbSet<BookStatusTable> BookStatusTables { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {




            modelBuilder.Entity<AppUserTable>()
                .HasMany(e => e.MovieTransitionTables)
                .WithRequired(e => e.AppUserTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUserTable>()
              .HasMany(e => e.BookTransitionTables)
              .WithRequired(e => e.AppUserTable)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUserTable>()
             .HasMany(e => e.SeriesTransitionTables)
             .WithRequired(e => e.AppUserTable)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<MovieTable>()
                .HasMany(e => e.MovieTransitionTables)
                .WithRequired(e => e.MovieTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusTable>()
                .HasMany(e => e.MovieTransitionTables)
                .WithRequired(e => e.StatusTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusTable>()
                .HasMany(e => e.SeriesTransitionTables)
                .WithRequired(e => e.StatusTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookTable>()
                .HasMany(e => e.BookTransitionTables)
                .WithRequired(e => e.BookTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EpisodesTable>()
                .HasMany(e => e.SeriesTransitionTables)
                .WithRequired(e => e.EpisodesTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SeriesTable>()
               .HasMany(e => e.EpisodesTables)
               .WithRequired(e => e.SeriesTable)
               .WillCascadeOnDelete(false);




        }
    }
}
