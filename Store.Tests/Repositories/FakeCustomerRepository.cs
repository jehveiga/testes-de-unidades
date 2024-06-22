using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    internal class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(string document)
        {
            if (document == "12345678911")
                return new Customer("Bruce Wayne", "batman@teste.io");

            return null;
        }
    }
}
