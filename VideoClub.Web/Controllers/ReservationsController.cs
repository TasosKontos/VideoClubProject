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
        private readonly IMoviesService _moviesService;
        private readonly ICopiesService _copiesService;
        private readonly IUsersService _usersService;
        private readonly IReservationService _reservationService;
        private readonly ICustomerService _customerService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationsController(ICustomerService customerService,IReservationService reservationService,IUsersService usersService,ICopiesService copiesService, IMoviesService moviesService, UserManager<ApplicationUser> userManager)
        {
            _reservationService = reservationService;
            _usersService = usersService;
            _moviesService = moviesService;
            _copiesService = copiesService;
            _userManager = userManager;
            _customerService = customerService;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateReservationAdmin(int movieId)
        {
            var copy = _copiesService.GetAvailableCopyForMovieId(movieId);

            var movie = _moviesService.FindMovieById(movieId);

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

            var userInContext = _usersService.GetUserByUsername(user.Id);

            var res = new Reservation();

            res.ApplicationUser = userInContext;

            res.MovieCopy = _copiesService.GetMovieCopyById(reservation.MovieCopyId);
            res.From = reservation.From;
            res.To = reservation.To;
            res.Comments = reservation.Comments;

           _reservationService.AddReservation(res);

            return RedirectToAction("ListMovies", "Movies");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateReservationForCustomer(string customerId)
        {
            var reservation = new Reservation();
            var user = _usersService.GetUserById(customerId);

            reservation.ApplicationUser = user;
            reservation.From = DateTime.Now;
            reservation.To = DateTime.Now.AddDays(7);

            var availableMovies = _moviesService.GetAvailableMovies();

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
            reservation.ApplicationUser = _usersService.GetUserById(reservation.ApplicationUser.Id);
            var movieId = model.SelectedMovieId;
            reservation.MovieCopy =_copiesService.GetAvailableCopyForMovieId(movieId);
           _reservationService.AddReservation(reservation);
            return RedirectToAction("ListCustomers", "Customers");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListReservationsForCustomer(string customerId)
        {
            var model = _customerService.GetReservationsForCustomerId(customerId);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListActiveReservations()
        {
            var model = _reservationService.GetActiveReservations();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ReturnMovie(int reservationId)
        {
           _reservationService.ReturnMovie(reservationId);

            var result = new { success = true, message = "Successfully returned movie!" };
            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListReservations()
        {
            var model = _reservationService.GetReservations();
            return View(model);
        }
    }
}
