using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    internal class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order) { }
    }
}
