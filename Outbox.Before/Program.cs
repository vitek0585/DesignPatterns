using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Outbox.Before
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
            private readonly IEventBus _eventBus;


            public RegisterCustomerCommandHandler(
                ICustomerRepository customerRepository,
                ICustomerUniquenessChecker customerUniquenessChecker,
                IEventBus eventBus)
            {
                this._customerRepository = customerRepository;
                _customerUniquenessChecker = customerUniquenessChecker;
                _eventBus = eventBus;
            }

            public async Task<CustomerDto> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = new Customer(request.Email, request.Name, this._customerUniquenessChecker);

                await this._customerRepository.AddAsync(customer);

                await this._customerRepository.UnitOfWork.CommitAsync(cancellationToken);

                // End of transaction--------------------------------------------------------

                this._eventBus.Send(new CustomerRegisteredIntegrationEvent(customer.Id));

                return new CustomerDto { Id = customer.Id };
            }
        }
    }
}
