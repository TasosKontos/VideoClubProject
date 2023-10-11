using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure;
using VideoClub.Common.Services;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Web.Models.MovieRents;

namespace VideoClub.Web.Controllers
{
    public class MovieRentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMoviesService _moviesService;
        private readonly ICopiesService _copiesService;
        private readonly IUsersService _usersService;
        private readonly IRentsService _rentService;
        private readonly ICustomerService _customerService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MovieRentsController(IMapper mapper, ICustomerService customerService,IRentsService rentService,IUsersService usersService,ICopiesService copiesService, IMoviesService moviesService, UserManager<ApplicationUser> userManager)
        {
            _rentService = rentService;
            _usersService = usersService;
            _moviesService = moviesService;
            _copiesService = copiesService;
            _userManager = userManager;
            _customerService = customerService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateMovieRentAdmin(int movieId)
        {
            var copy = _copiesService.GetAvailableCopyForMovieId(movieId);

            var movie = _moviesService.FindMovieById(movieId);

            var model = new MovieRentAdminViewModel();
            model.MovieId = movieId;
            model.MovieCopyId = copy.Id;
            model.From = DateTime.Now;
            model.To = DateTime.Now.AddDays(7);


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

            var rent = _mapper.Map<MovieRent>(movRent ); ;

            rent.ApplicationUser = userInContext;

           _rentService.AddMovieRent(rent);

            return RedirectToAction("ListMovies", "Movies");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateMovieRentForCustomer(string customerId)
        {
            var user = _usersService.GetUserById(customerId);

            MovieRentForCustomerViewModel model = new MovieRentForCustomerViewModel();

            model.ApplicationUserId = user.Id;
            model.UserName = user.UserName;
            model.From = DateTime.Now;
            model.To = DateTime.Now.AddDays(7);

            var availMovies =  _moviesService.GetAvailableMovies();

            var selectList = new SelectList(availMovies, "Id", "Title");

            model.AvailableMovies = availMovies;

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateMovieRentForCustomer(MovieRentForCustomerViewModel model)
        {

            MovieRent rent = new MovieRent();
            rent = _mapper.Map<MovieRent>(model);
            rent.MovieCopy =_copiesService.GetAvailableCopyForMovieId(model.SelectedMovieId);
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
