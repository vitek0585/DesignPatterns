using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Outbox.Before
{
    public class RegisterCustomerCommand : IRequest<CustomerDto>
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}