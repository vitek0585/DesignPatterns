namespace Outbox.Before
{
    public interface IEventBus
    {
        void Send(CustomerRegisteredIntegrationEvent customerRegisteredIntegrationEvent);
    }
}