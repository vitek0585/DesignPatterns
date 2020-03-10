namespace Specification.Before.Extensions
{
//    repository still gives us Query method,
// that is not good, I think, because, it leads to uncontrolled usage.So, we can move logic to repository:
    public class DataService
    {
        public static void Search(IUserRepository repository)
        {
            var users1 = repository.Query().FindWithActivePhones();

            var users2 = repository.Query().FindWithLoginPrefix("log");

            var users3 = repository.Query().FindWithPhoneNumber("111-22-33");
        }
    }
}