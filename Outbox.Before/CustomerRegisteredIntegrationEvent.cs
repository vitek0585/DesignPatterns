namespace Outbox.Before
{
    internal class CustomerRegisteredIntegrationEvent
    {
        private int id;

        public CustomerRegisteredIntegrationEvent(int id)
        {
            this.id = id;
        }
    }
}