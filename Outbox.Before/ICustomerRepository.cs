using System.Threading;
using System.Threading.Tasks;

namespace Outbox.Before
{
    internal interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        IUnitOfWork UnitOfWork { get; set; }
    }

    internal interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken);
    }
}