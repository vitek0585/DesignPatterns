using System;
using System.Linq.Expressions;

namespace Specification.After.Specification
{
    // Where T is a business entity class (User in our example)
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSatisfiedBy { get; }
    }
}