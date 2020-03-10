using System.Collections.Generic;
using System.Linq;
using Specification.After.Models;

namespace Specification.After.Specification
{
	public interface IUserRepository
    {
        void Add(User user);
        User Get(int id);
        IEnumerable<User> Get(ISpecification<User> specification);
    }

    public sealed class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Set<User>().Add(user);
        }

        public User Get(int id)
        {
            return _context.Set<User>().FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<User> Get(ISpecification<User> specification)
        {
            return _context.Set<User>()
                .Where(specification.IsSatisfiedBy)
                .AsEnumerable();
        }
    }
}