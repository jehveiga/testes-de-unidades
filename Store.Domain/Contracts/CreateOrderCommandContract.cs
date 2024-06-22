using Flunt.Validations;
using Store.Domain.Commands;

namespace Store.Domain.Contracts
{
    public class CreateOrderCommandContract : Contract<CreateOrderCommand>
    {
        public CreateOrderCommandContract(CreateOrderCommand orderCommand)
        {
            Requires()
                .IsGreaterOrEqualsThan(orderCommand.Customer, 11, "Customer", "Cliente inválido")
                .IsGreaterThan(orderCommand.ZipCode, 8, "ZipCode", "CEP inválido");
        }
    }

}
