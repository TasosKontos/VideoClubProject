using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoClub.Common.Services;
using VideoClub.Core.Interfaces;

namespace VideoClub.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListCustomers()
        {
            var model = _unitOfWork.Customer.GetAllCustomersWithReservationCount().ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult ListCustomers(string action)
        {
            string[] actionParts = action.Split(':');
            var customerId = actionParts[1];
            if (actionParts[0] == "Reservations")
            {
                return RedirectToAction("ListReservationsForCustomer", "Reservations", new { customerId = customerId });
            }
            else
            {
                return RedirectToAction("CreateReservationForCustomer", "Reservations", new { customerId = customerId });
            }
        }
    }
}
