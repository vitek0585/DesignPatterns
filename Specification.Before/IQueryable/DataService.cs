using System.Linq;

namespace Specification.Before.IQueryable
{
//    This is fast and simple solution, but it has disadvantages:
//
//    You need to repeat code every time, when you need to reuse the condition.It's not very good technique: you can forget to change condition at some place and so on - all disadvantages of code repetition.
//    Business logic is distributed in code.You can't enumerate all business requirements in code, because all filters are used in different parts of application.
//    Hard testable.You can't check your business logic separately from storage.
    public class DataService
    {
		public static void Search(IUserRepository repository)
        {
            var users1 = repository.Query()
                .Where(o => o.Contacts.Any(c => c is Phone && c.IsActive))
                .ToArray();

            var users2 = repository.Query()
                .Where(o => o.Login.StartsWith("log"))
                .ToArray();

            var users3 = repository.Query()
                .Where(o => o.Contacts.Any(c => c is Phone && ((Phone) c).PhoneNumber == "111-22-33"))
                .ToArray();
        }
	}
}