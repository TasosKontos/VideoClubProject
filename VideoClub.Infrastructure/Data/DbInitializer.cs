﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Enumerations;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            if (!db.Movies.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "nikoskorobos@email.com",
                    Email = "nikoskorobos@email.com",
                    Name = "Nikos",
                    Surname = "Korobos",
                };
                var result = await userManager.CreateAsync(user, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                    Console.WriteLine("Success!!!!!!!!!");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        // Log or handle each error as needed
                        Console.WriteLine($"Error: {error.Code}, Description: {error.Description}");
                    }
                }

                var movies = new List<Movie> {
                    new Movie{Title="Movie 1", Genre=Genre.Mystery},
                    new Movie{Title="Movie 2", Genre=Genre.Adventure},
                    new Movie{Title="Movie 3", Genre=Genre.Mystery},
                    new Movie{Title="Movie 4", Genre= Genre.Thriller}
                };
                //movies.ForEach(m => db.Movies.Add(m));

                var rents = new List<MovieRent>
                {
                    new MovieRent{From=DateTime.Parse("2023-09-26"), To=DateTime.Parse("2023-09-03"), ApplicationUser=user},
                    new MovieRent{From=DateTime.Parse("2023-09-10"), To=DateTime.Parse("2023-09-17"), ApplicationUser = user},
                    new MovieRent{From=DateTime.Parse("2023-09-27"), To=null, ApplicationUser=user}
                };
                //reservations.ForEach(r => db.Reservations.Add(r));

                var copies = new List<MovieCopy>
                {
                    new MovieCopy{},
                    new MovieCopy{},
                    new MovieCopy{}
                };
                //copies.ForEach(c => db.MovieCopies.Add(c));

                copies[0].MovieRents.Add(rents[0]);
                copies[1].MovieRents.Add(rents[1]);
                copies[2].MovieRents.Add(rents[2]);

                movies[0].Copies.Add(copies[0]);
                movies[0].Copies.Add(copies[1]);
                movies[0].Copies.Add(copies[2]);

                await db.Movies.AddRangeAsync(movies);
                await db.MovieRents.AddRangeAsync(rents);
                await db.MovieCopies.AddRangeAsync(copies);

                user.MovieRents.Add(rents[0]);
                user.MovieRents.Add(rents[1]);
                user.MovieRents.Add(rents[2]);

            }

            await db.SaveChangesAsync();
        }
    }
}
