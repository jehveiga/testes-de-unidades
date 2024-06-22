using Flunt.Validations;
using Store.Domain.Commands;

namespace Store.Domain.Contracts
{
    public class CreateOrderCommandContract : Contract<CreateOrderCommand>
    {
        public CreateOrderCommandContract(CreateOrderCommand orderCommand)
        {
            Requires()
                .IsNotNull(orderCommand.Items, "Itens", "Sem Itens")
                .IsGreaterOrEqualsThan(orderCommand.Customer, 8, "Customer", "Cliente inválido")
                .IsLowerOrEqualsThan(orderCommand.ZipCode, 8, "ZipCode", "CEP inválido");
        }
    }

}
