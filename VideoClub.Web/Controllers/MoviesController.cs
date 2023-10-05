﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoClub.Common.Services;
using VideoClub.Core.Interfaces;
using VideoClub.Web.Models;
using X.PagedList;

namespace VideoClub.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly  IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult ListMovies(string genre, string search, int? page)
        {
            SearchModel searchModel = new SearchModel((search ?? ""), (genre ?? ""));

            var moviesWithCount = _unitOfWork.Movie.GetAllMoviesWithCount(searchModel.titleSearch, searchModel.genreFilter);


            int pageSize = 3;
            int pageNumber = (page ?? 1);

            var pagedMovies = moviesWithCount.OrderBy(m => m.availableCopyCount).ToPagedList(pageNumber, pageSize);


            return View(pagedMovies);
        }

        [HttpPost]
        public ActionResult ListMovies(int movieId)
        {
            return RedirectToAction("CreateReservationAdmin", "Reservations", new { movieId = movieId });
        }
    }
}