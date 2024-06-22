using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    internal class FakeDiscountrepository : IDiscountRepository
    {
        public Discount Get(string code)
        {
            if (code == "12345678")
                return new Discount(10, DateTime.Now.AddDays(5));

            if (code == "11111111")
                return new Discount(10, DateTime.Now.AddDays(-5));

            return null;
        }
    }
}
