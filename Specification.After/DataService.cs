using Specification.After.Specification;

namespace Specification.After
{
    public class DataService
    {
        public static void Search(IUserRepository repository)
        {
            var users1 = repository.Get(new ActivePhonesSpecification());

            var users2 = repository.Get(new LoginPrefixSpecification("log"));

            var users3 = repository.Get(new PhoneNumberSpecification("111-22-33"));
        }
    }
}