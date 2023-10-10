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
    public class MovieRentsController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ICopiesService _copiesService;
        private readonly IUsersService _usersService;
        private readonly IRentsService _rentService;
        private readonly ICustomerService _customerService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MovieRentsController(ICustomerService customerService,IRentsService rentService,IUsersService usersService,ICopiesService copiesService, IMoviesService moviesService, UserManager<ApplicationUser> userManager)
        {
            _rentService = rentService;
            _usersService = usersService;
            _moviesService = moviesService;
            _copiesService = copiesService;
            _userManager = userManager;
            _customerService = customerService;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateMovieRentAdmin(int movieId)
        {
            var copy = _copiesService.GetAvailableCopyForMovieId(movieId);

            var movie = _moviesService.FindMovieById(movieId);

            //Tuple<Movie, MovieCopy> model = new Tuple<Movie, MovieCopy>(movie, copy);
            var model = new MovieRentAdminViewModel();
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
        public async Task<ActionResult> CreateMovieRentAdmin(MovieRentAdminViewModel movRent)
        { 

            var user = await  _userManager.FindByNameAsync(movRent.Username ?? "");

            if (user == null)
            {
                return View(movRent);
            }

            var userInContext = _usersService.GetUserByUsername(user.Id);

            var rent = new MovieRent();

            rent.ApplicationUser = userInContext;

            rent.MovieCopy = _copiesService.GetMovieCopyById(movRent.MovieCopyId);
            rent.From = movRent.From;
            rent.To = movRent.To;
            rent.Comments = movRent.Comments;

           _rentService.AddMovieRent(rent);

            return RedirectToAction("ListMovies", "Movies");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateMovieRentForCustomer(string customerId)
        {
            var rent = new MovieRent();
            var user = _usersService.GetUserById(customerId);

            rent.ApplicationUser = user;
            rent.From = DateTime.Now;
            rent.To = DateTime.Now.AddDays(7);

            var availableMovies = _moviesService.GetAvailableMovies();

            MovieRentForCustomerViewModel model = new MovieRentForCustomerViewModel();
            model.MovieRent = rent;
            model.AvailableMovies = availableMovies;

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateMovieRentForCustomer(MovieRentForCustomerViewModel model)
        {
            System.Diagnostics.Debug.WriteLine("selected movie id is " + model.SelectedMovieId);

            var rent = model.MovieRent;
            rent.ApplicationUser = _usersService.GetUserById(rent.ApplicationUser.Id);
            var movieId = model.SelectedMovieId;
            rent.MovieCopy =_copiesService.GetAvailableCopyForMovieId(movieId);
           _rentService.AddMovieRent(rent);
            return RedirectToAction("ListCustomers", "Customers");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListMovieRentsForCustomer(string customerId)
        {
            var model = _customerService.GetMovieRentsForCustomerId(customerId);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListActiveMovieRents()
        {
            var model = _rentService.GetActiveMovieRents();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ReturnMovie(int rentId)
        {
           _rentService.ReturnMovie(rentId);

            var result = new { success = true, message = "Successfully returned movie!" };
            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListMovieRents()
        {
            var model = _rentService.GetMovieRents();
            return View(model);
        }
    }
}
