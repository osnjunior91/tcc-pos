namespace Customer.Model
{
    public class CustomerCreateRequest
    {
        public string Document { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
