using System;
using System.Linq;
using System.Linq.Expressions;
using Specification.After.Models;

namespace Specification.After.Composite
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T item);
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Left { get; set; }
        public ISpecification<T> Right { get; set; }
        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }
        public bool IsSatisfiedBy(T item) => Left.IsSatisfiedBy(item) && Right.IsSatisfiedBy(item);
    }

    public class OrSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Left { get; set; }
        public ISpecification<T> Right { get; set; }
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }
        public bool IsSatisfiedBy(T item) => Left.IsSatisfiedBy(item) || Right.IsSatisfiedBy(item);
    }

    public class NotSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Specification { get; set; }
        public NotSpecification(ISpecification<T> specification)
        {
            Specification = specification;
        }
        public bool IsSatisfiedBy(T item) => !Specification.IsSatisfiedBy(item);
    }

    public class ActivePhonesSpecification : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user) =>
            user.Contacts.Any(c => c is Phone && c.IsActive);

    }

    public class LoginPrefixSpecification : ISpecification<User>
    {
        private readonly string _prefix;

        public LoginPrefixSpecification(string prefix)
        {
            _prefix = prefix;
        }

        public bool IsSatisfiedBy(User user) => 
            user.Login.StartsWith(_prefix);
    }

    public class PhoneNumberSpecification : ISpecification<User>
    {
        private readonly string _phoneNumber;

        public PhoneNumberSpecification(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public bool IsSatisfiedBy(User user) =>
            user.Contacts.Any(c => c is Phone phone && phone.PhoneNumber == _phoneNumber);
    }

}