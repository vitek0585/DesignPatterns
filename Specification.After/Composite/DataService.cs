
namespace Specification.After.Composite
{
    public class DataService
    {
        public static void Search(IUserRepository repository)
        {
            var users1 = repository.Get(new ActivePhonesSpecification()
                .And(new LoginPrefixSpecification("log")
                    .Or(new PhoneNumberSpecification("111-1222-222"))));
        }
    }
}