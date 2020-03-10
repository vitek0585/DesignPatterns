using System;
using System.Collections.Generic;
using System.Text;

namespace Specification.Before
{
	public sealed class User
    {
        public User()
        {
            Contacts = new List<Contact>();
        }
        public int Id { get; set; }

        public string Login { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Contact> Contacts { get; }
    }

    public abstract class Contact
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }

    public class Phone : Contact
    {
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Email : Contact
    {
        public string Value { get; set; }
    }
}
