using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    internal class FakeDeliveryFeeRepositoy : IDeliveryFeeRepository
    {
        public decimal Get(string zipCode)
        {
            return 10;
        }
    }
}
