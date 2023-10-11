using AutoMapper;
using VideoClub.Core.Entities;
using VideoClub.Web.Models.MovieRents;

namespace VideoClub.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<MovieRentAdminViewModel, MovieRent>();
            CreateMap<MovieRentForCustomerViewModel, MovieRent>();
        }
    }
}
