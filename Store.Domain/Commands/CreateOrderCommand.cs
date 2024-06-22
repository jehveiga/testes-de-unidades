using Flunt.Validations;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Contracts;

namespace Store.Domain.Commands
{
    public class CreateOrderCommand : Contract<CreateOrderCommandContract>, ICommand
    {
        public CreateOrderCommand()
        {
            Items = new List<CreateOrderItemCommand>();
        }

        public CreateOrderCommand(string customer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items)
        {
            Customer = customer;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Items = items;
        }

        public string Customer { get; set; }
        public string ZipCode { get; set; }
        public string PromoCode { get; set; }
        public IList<CreateOrderItemCommand> Items { get; set; }

        public void Validate()
        {
            AddNotifications(new CreateOrderCommandContract(this));
        }
    }
}
