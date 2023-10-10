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

        [HttpPost]
        public ActionResult ListCustomers(string action)
        {
            string[] actionParts = action.Split(':');
            var customerId = actionParts[1];
            if (actionParts[0] == "MovieRents")
            {
                return RedirectToAction("ListMovieRentsForCustomer", "MovieRents", new { customerId = customerId });
            }
            else
            {
                return RedirectToAction("CreateMovieRentForCustomer", "MovieRents", new { customerId = customerId });
            }
        }
    }
}
