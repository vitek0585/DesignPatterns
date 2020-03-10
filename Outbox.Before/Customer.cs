namespace Outbox.Before
{
    internal class Customer
    {
        private object email;
        private object name;
        private ICustomerUniquenessChecker _customerUniquenessChecker;

        public Customer(object email, object name, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            this.email = email;
            this.name = name;
            _customerUniquenessChecker = customerUniquenessChecker;
        }

        public int Id { get; set; }
    }
}