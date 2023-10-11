using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoClub.Common.Services;
using VideoClub.Core.Interfaces;

namespace VideoClub.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListCustomers()
        {
            var model = _customerService.GetAllCustomersWithMovieRentCount().ToList();
            return View(model);
        }
    }
}
