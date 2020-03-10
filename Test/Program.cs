using System.Linq;
using NUnit.Framework;
using Specification.After.Models;
using Specification.After.Specification;

namespace Specification.Test
{
    [TestFixture]
    public class SpecificationTest
    {
        [Test]
        public void FindWithActivePhonesTest()
        {
            var user = new User
            {
                Id = 1,
                Login = "login"
            };
            user.Contacts.Add(new Phone {IsActive = true, PhoneNumber = "123-321"});

            var queryable = new[] {user}.AsQueryable();

            var specification = new ActivePhonesSpecification();
            var result = queryable.Where(specification.IsSatisfiedBy);

            CollectionAssert.AreEquivalent(new[] {1}, result.Select(o => o.Id));
        }

        [Test]
        public void FindWithActivePhonesWithoutStorageTest()
        {
            var user = new User
            {
                Id = 1,
                Login = "login"
            };
            user.Contacts.Add(new Phone { IsActive = true, PhoneNumber = "123-321" });

            var specification = new ActivePhonesSpecification();

            Assert.IsTrue(specification.IsSatisfiedBy.Compile().Invoke(user));
        }
    }
}
