namespace VideoClub.Web.Models.Customers
{
    public class ListCustomerViewModel
    {
        public string customerId { get; set; }
        public string customerUsername { get; set; }
        public string customerName { get; set; }
        public string customerSurname { get; set; }
        public int activeMovieRents { get; set; }
    }
}
