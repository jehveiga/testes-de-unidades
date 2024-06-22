using Flunt.Validations;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Contracts;

namespace Store.Domain.Commands
{
    public class CreateOrderItemCommand : Contract<CreateOrderItemCommandContract>, ICommand
    {
        public CreateOrderItemCommand()
        {

        }

        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product { get; set; }
        public int Quantity { get; set; }


        public void Validate()
        {
            AddNotifications(new CreateOrderItemCommandContract(this));
        }
    }
}
