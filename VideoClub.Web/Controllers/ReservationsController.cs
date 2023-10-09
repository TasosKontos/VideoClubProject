using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideoClub.Common.Services;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Web.Models;

namespace VideoClub.Web.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationsController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateReservationAdmin(int movieId)
        {
            var copy = _unitOfWork.Copy.GetAvailableCopyForMovieId(movieId);

            var movie = _unitOfWork.Movie.FindMovieById(movieId);

            //Tuple<Movie, MovieCopy> model = new Tuple<Movie, MovieCopy>(movie, copy);
            var model = new ReservationAdminViewModel();
            model.MovieId = movieId;
            model.MovieCopyId = copy.Id;
            model.From = DateTime.Now;
            model.To = DateTime.Now.AddDays(7);
            //model.Comments = "";
            //model.Username = "";
            TempData["Movie Title"] = movie.Title;

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> CreateReservationAdmin(ReservationAdminViewModel reservation)
        { 

            var user = await  _userManager.FindByNameAsync(reservation.Username ?? "");

            if (user == null)
            {
                return View(reservation);
            }

            var userInContext = _unitOfWork.User.GetUserByUsername(user.Id);

            var res = new Reservation();

            res.ApplicationUser = userInContext;

            res.MovieCopy = _unitOfWork.Copy.GetMovieCopyById(reservation.MovieCopyId);
            res.From = reservation.From;
            res.To = reservation.To;
            res.Comments = reservation.Comments;

            _unitOfWork.Reservation.AddReservation(res);

            return RedirectToAction("ListMovies", "Movies");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateReservationForCustomer(string customerId)
        {
            var reservation = new Reservation();
            var user = _unitOfWork.User.GetUserById(customerId);

            reservation.ApplicationUser = user;
            reservation.From = DateTime.Now;
            reservation.To = DateTime.Now.AddDays(7);

            var availableMovies = _unitOfWork.Movie.GetAvailableMovies();

            ReservationForCustomerViewModel model = new ReservationForCustomerViewModel();
            model.Reservation = reservation;
            model.AvailableMovies = availableMovies;

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateReservationForCustomer(ReservationForCustomerViewModel model)
        {
            System.Diagnostics.Debug.WriteLine("selected movie id is " + model.SelectedMovieId);

            var reservation = model.Reservation;
            reservation.ApplicationUser = _unitOfWork.User.GetUserById(reservation.ApplicationUser.Id);
            var movieId = model.SelectedMovieId;
            reservation.MovieCopy = _unitOfWork.Copy.GetAvailableCopyForMovieId(movieId);
            _unitOfWork.Reservation.AddReservation(reservation);
            return RedirectToAction("ListCustomers", "Customers");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListReservationsForCustomer(string customerId)
        {
            var model = _unitOfWork.Customer.GetReservationsForCustomerId(customerId);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListActiveReservations()
        {
            var model = _unitOfWork.Reservation.GetActiveReservations();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ReturnMovie(int reservationId)
        {
            _unitOfWork.Reservation.ReturnMovie(reservationId);

            var result = new { success = true, message = "Successfully returned movie!" };
            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListReservations()
        {
            var model = _unitOfWork.Reservation.GetReservations();
            return View(model);
        }
    }
}
