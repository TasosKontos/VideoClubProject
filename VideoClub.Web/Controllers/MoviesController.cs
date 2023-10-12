using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoClub.Common.Services;
using VideoClub.Core.Interfaces;
using VideoClub.Core.Interfaces.Helpers;
using VideoClub.Web.Models.Movies;
using X.PagedList;

namespace VideoClub.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;

        public MoviesController(IMapper mapper, IMoviesService moviesService)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult ListMovies(string genre, string search, int? page)
        {
            SearchViewModel searchModel = new SearchViewModel((search ?? ""), (genre ?? ""));

            var moviesWithCount = _moviesService.GetAllMoviesWithCount(searchModel.titleSearch, searchModel.genreFilter);
           
            var model = moviesWithCount.ProjectTo<ListMovieViewModel>(_mapper.ConfigurationProvider);

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            var pagedMovies = model.OrderBy(m => m.availableCopyCount).ToPagedList(pageNumber, pageSize);

            return View(pagedMovies);
        }
    }
}
