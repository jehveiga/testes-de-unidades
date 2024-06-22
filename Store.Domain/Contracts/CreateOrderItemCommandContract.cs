using Flunt.Validations;
using Store.Domain.Commands;

namespace Store.Domain.Contracts
{
    public class CreateOrderItemCommandContract : Contract<CreateOrderItemCommand>
    {
        public CreateOrderItemCommandContract(CreateOrderItemCommand orderItemCommand)
        {
            Requires()
                .IsGreaterOrEqualsThan(orderItemCommand.Product.ToString(), 32, "Product", "Produto inválido")
                .IsGreaterThan(orderItemCommand.Quantity, 0, "Quantity", "Quantidade inválida");
        }

    }
}
