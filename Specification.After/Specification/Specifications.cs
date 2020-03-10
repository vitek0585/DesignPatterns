using System;
using System.Linq;
using System.Linq.Expressions;
using Specification.After.Models;

namespace Specification.After.Specification
{
	public class ActivePhonesSpecification : ISpecification<User>
    {
        public Expression<Func<User, bool>> IsSatisfiedBy =>
            o => o.Contacts.Any(c => c is Phone && c.IsActive);
    }

    public class LoginPrefixSpecification : ISpecification<User>
    {
        public LoginPrefixSpecification(string prefix)
        {
            IsSatisfiedBy = o => o.Login.StartsWith(prefix);
        }
        public Expression<Func<User, bool>> IsSatisfiedBy { get; }
    }

    public class PhoneNumberSpecification : ISpecification<User>
    {
        public PhoneNumberSpecification(string phoneNumber)
        {
            IsSatisfiedBy = o => o.Contacts.Any(c => c is Phone && ((Phone) c).PhoneNumber == phoneNumber);
        }
        public Expression<Func<User, bool>> IsSatisfiedBy { get; }
    }
}