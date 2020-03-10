using System.Collections.Generic;
using System.Linq;

namespace Specification.Before.Extensions
{
	public static class UserQueryExtensions
    {
        public static IEnumerable<User> FindWithActivePhones(this IQueryable<User> query)
        {
            return query.Where(o => o.Contacts.Any(c => c is Phone && c.IsActive))
                .AsEnumerable();
        }

        public static IEnumerable<User> FindWithLoginPrefix(this IQueryable<User> query, string prefix)
        {
            return query.Where(o => o.Login.StartsWith(prefix))
                .AsEnumerable();
        }

        public static IEnumerable<User> FindWithPhoneNumber(this IQueryable<User> query, string phoneNumber)
        {
            return query.Where(o => o.Contacts.Any(c => c is Phone && (c as Phone).PhoneNumber == phoneNumber))
                .AsEnumerable();
        }
    }
}