using System.Linq;

namespace Specification.Before.Extensions
{
	public interface IUserRepository
    {
        void Add(User user);
        User Get(int id);
        IQueryable<User> Query();
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

        public IQueryable<User> Query()
        {
            return _context.Set<User>();
        }
    }
}