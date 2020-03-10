using System.Collections.Generic;
using System.Linq;

namespace Specification.Before.Repository
{
	public interface IUserRepository
    {
        void Add(User user);
        User Get(int id);
        IEnumerable<User> FindWithActivePhones();
        IEnumerable<User> FindWithLoginPrefix(string prefix);
        IEnumerable<User> FindWithPhoneNumber(string phoneNumber);
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

        public IEnumerable<User> FindWithActivePhones()
        {
            return _context.Set<User>().Where(o => o.Contacts.Any(c => c is Phone && c.IsActive))
                .AsEnumerable();
        }

        public IEnumerable<User> FindWithLoginPrefix(string prefix)
        {
            return _context.Set<User>().Where(o => o.Login.StartsWith(prefix))
                .AsEnumerable();
        }

        public IEnumerable<User> FindWithPhoneNumber(string phoneNumber)
        {
            return _context.Set<User>().Where(o => o.Contacts.Any(c => c is Phone && (c as Phone).PhoneNumber == phoneNumber))
                .AsEnumerable();
        }
    }
}