using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoClub.Common.Services;
using VideoClub.Core.Interfaces;
using VideoClub.Web.Models.Customers;

namespace VideoClub.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomersController(IMapper mapper, ICustomerService customerService)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListCustomers()
        {
            var customerList = _customerService.GetAllCustomersWithMovieRentCount().ToList();
            
            var model = _mapper.Map<List<ListCustomerViewModel>>(customerList);
            
            return View(model);
        }
    }
}
