﻿using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Utils;

namespace Store.Domain.Handlers
{
    public class OrderHandler : Notifiable<Notification>, IHandler<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _feeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(ICustomerRepository customerRepository, IDeliveryFeeRepository feeRepository, IDiscountRepository discountRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _feeRepository = feeRepository;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Pedido inválido", command.Notifications);

            // 1. Recupera o cliente
            var customer = _customerRepository.Get(command.Customer);

            // 2. Calcula a taxa de entrega
            var deliveryFee = _feeRepository.Get(command.ZipCode);

            // 3. Obtém o cupom de desconto
            var discount = _discountRepository.Get(command.PromoCode);

            // 4. Gera o pedido
            var products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();
            var order = new Order(customer, deliveryFee, discount);
            foreach (var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            // 5. Agrupa ass notificações
            AddNotifications(order.Notifications);

            if (!IsValid)
                return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);

            // 7. Retorna o resultado
            _orderRepository.Save(order);
            return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso", order);
        }
    }
}
