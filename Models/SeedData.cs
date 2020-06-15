using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
namespace MvcMovie.Models {
    public static class SeedData {
        public static void PrepPopulation (IApplicationBuilder app) {
            using (var serviceScope = app.ApplicationServices.CreateScope ()) {
                SeedDatas (serviceScope.ServiceProvider.GetService<MvcMovieContext> ());
            }
        }
        public static void SeedDatas (MvcMovieContext context) {
            System.Console.WriteLine ("Appling Migrations...");
            context.Database.Migrate ();
            // Look for any movies.

            if (!context.Movie.Any ()) {
                System.Console.WriteLine ("Adding data -seeding...");
                context.Movie.AddRange (
                    new Movie() {
                        Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse ("1989-2-12"),
                            Genre = "Romantic Comedy",
                            Rating = "R",
                            Price = 7.99M
                    },

                    new Movie() {
                        Title = "Ghostbusters ",
                            ReleaseDate = DateTime.Parse ("1984-3-13"),
                            Genre = "Comedy",
                            Rating = "A",
                            Price = 8.99M
                    },

                    new Movie() {
                        Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse ("1986-2-23"),
                            Genre = "Comedy",
                            Rating = "B",
                            Price = 9.99M
                    },

                    new Movie() {
                        Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse ("1959-4-15"),
                            Genre = "Western",
                            Rating = "E",
                            Price = 3.99M
                    }
                );
                context.SaveChanges ();
            } else {
                System.Console.WriteLine ("Already have data - not seeding ");
            }

        }
    }
}
