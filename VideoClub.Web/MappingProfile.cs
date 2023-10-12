using AutoMapper;
using VideoClub.Core.Entities;
using VideoClub.Web.Models.MovieRents;
using VideoClub.Web.Models.Movies;
using VideoClub.Web.Models.Customers;
using VideoClub.Core.Interfaces.Helpers;

namespace VideoClub.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<MovieRentAdminViewModel, MovieRent>();
            CreateMap<MovieRentForCustomerViewModel, MovieRent>();
            CreateMap<MovieRent, ListMovieRentViewModel>();     
            CreateMap<MovieWCount, ListMovieViewModel>();
            CreateMap<CustomerWMovieRentCount, ListCustomerViewModel>();
        }
    }
}
