namespace Utils.Api.Model.Request
{
    public class GetDistanceRequest
    {
        public AddressRequest From { get; set; }

        public AddressRequest To { get; set; }
    }
}
