using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Models
{
    class MovieDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieDirection> MovieDirections { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=DESKTOP-ELNAA5R\SQLEXPRESS;DataBase=Movies;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // For Alexey Beletskiy --> in my humble opinion column names on the scheme of DB are more suspicious than my properties therefore not implemented

            modelBuilder.Entity<Actor>().Property(id => id.Id).IsRequired();
            modelBuilder.Entity<Actor>().Property(fname => fname.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Actor>().Property(lname => lname.LastName).HasMaxLength(20);
            modelBuilder.Entity<Actor>().Property(gender => gender.Gender).HasMaxLength(1);
            modelBuilder.Entity<Actor>().HasMany<MovieCast>(actor => actor.MovieCasts).WithOne(moviecast => moviecast.Actor);

            modelBuilder.Entity<Movie>().Property(id => id.Id).IsRequired();
            modelBuilder.Entity<Movie>().Property(title => title.Title).HasMaxLength(20);
            modelBuilder.Entity<Movie>().Property(lang => lang.Language).HasMaxLength(50);
            modelBuilder.Entity<Movie>().Property(country => country.Country).HasMaxLength(5);
            modelBuilder.Entity<Movie>().HasMany<MovieCast>(movie => movie.MovieCasts).WithOne(moviecast => moviecast.Movie);
            modelBuilder.Entity<Movie>().HasMany<MovieDirection>(movie => movie.MovieDirections).WithOne(moviedir => moviedir.Movie);
            modelBuilder.Entity<Movie>().HasMany<Rating>(movie => movie.Ratings).WithOne(raiting => raiting.Movie);
            modelBuilder.Entity<Movie>().HasMany<MovieGenre>(movie => movie.MovieGenres).WithOne(moviegenre => moviegenre.Movie);

            modelBuilder.Entity<Director>().Property(id => id.Id).IsRequired();
            modelBuilder.Entity<Director>().Property(fname => fname.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Director>().Property(lname => lname.LastName).HasMaxLength(20);
            modelBuilder.Entity<Director>().HasMany<MovieDirection>(director => director.MovieDirections).WithOne(moviedir => moviedir.Director);

            modelBuilder.Entity<Reviewer>().Property(id => id.Id).IsRequired();
            modelBuilder.Entity<Reviewer>().Property(name => name.Name).HasMaxLength(30);
            modelBuilder.Entity<Reviewer>().HasMany<Rating>(reviewer => reviewer.Ratings).WithOne(raiting => raiting.Reviewer);

            modelBuilder.Entity<Genre>().Property(id => id.Id).IsRequired();
            modelBuilder.Entity<Genre>().Property(title => title.Title).HasMaxLength(20);
            modelBuilder.Entity<Genre>().HasMany<MovieGenre>(genre => genre.MovieGenres).WithOne(moviegenre => moviegenre.Genre);

            modelBuilder.Entity<MovieCast>().Property(role => role.Role).HasMaxLength(30);
            modelBuilder.Entity<MovieCast>().HasKey(mc => new { mc.ActorId, mc.MovieId });

            modelBuilder.Entity<MovieDirection>().HasKey(md => new { md.DirectorId, md.MovieId });

            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<Rating>().HasKey(r => new { r.MovieId, r.ReviewerId });
        }
    }
}
