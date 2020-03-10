using System;

namespace Ambassador.After
{
    public class Client
    {
        private static readonly Action<string> _logger = Console.WriteLine;

        private readonly ServiceAmbassador _serviceAmbassador = new ServiceAmbassador();

        public long UseService(int value)
        {
            var result = _serviceAmbassador.DoRemoteFunction(value);
            _logger(GetType().Name + " Service result: " + result);
            return result;
        }
    }
}
