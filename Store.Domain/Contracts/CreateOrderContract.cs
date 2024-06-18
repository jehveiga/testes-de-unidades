using Flunt.Validations;
using Store.Domain.Entities;

namespace Store.Domain.Contracts
{
    public class CreateOrderContract : Contract<Order>
    {
        public CreateOrderContract(Order order)
        {
            Requires()
                .IsNotNull(order.Customer, "Customer", "Cliente inválido");
        }
    }
}
