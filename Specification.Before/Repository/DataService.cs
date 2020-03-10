namespace Specification.Before.Repository
{
    //    No dangerous Query method.But it's hard to test - filter methods are strongly connected to storage and Entity Framework.
    //   Now if we need to add new search features the class will grow
    public class DataService
    {
        public static void Search(IUserRepository repository)
        {
            var users1 = repository.FindWithActivePhones();

            var users2 = repository.FindWithLoginPrefix("log");

            var users3 = repository.FindWithPhoneNumber("111-22-33");
        }
    }
}