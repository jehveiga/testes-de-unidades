using Flunt.Validations;
using Store.Domain.Entities;

namespace Store.Domain.Contracts
{
    public class CreateOderItemContract : Contract<OrderItem>
    {
        public CreateOderItemContract(OrderItem orderItem)
        {
            Requires()
                .IsNotNull(orderItem.Product, "Product", "Produto inválido")
                .IsGreaterThan(orderItem.Quantity, 0, "Quantity", "A quantidade deve ser maior que zero");
        }
    }
}
