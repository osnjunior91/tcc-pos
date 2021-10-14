using BoaEntrega.Lib.Infrastructure.Data.Model;

namespace Order.Lib.Infrastructure.HttpClient.Customer
{
    public class CustomerResponse
    {
        public string Document { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public AddressModel Address { get; set; }
    }
}
