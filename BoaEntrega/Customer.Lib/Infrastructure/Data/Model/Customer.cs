using Amazon.DynamoDBv2.DataModel;
using BoaEntrega.Lib.Infrastructure.Data.Model;

namespace Customer.Lib.Infrastructure.Data.Model
{
    [DynamoDBTable("customer")]
    public class Customer : ModelBase
    {
        public string Document { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
    }
}
