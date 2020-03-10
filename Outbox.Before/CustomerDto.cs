using MediatR;

namespace Outbox.Before
{
    public class CustomerDto : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}