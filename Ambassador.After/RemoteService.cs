using System;
using System.Threading;

namespace Ambassador.After
{
    public class RemoteService : IRemoteServiceInterface
    {
        private readonly int _threshold = 200;
        private readonly Action<string> _logger;

        private static RemoteService _service = null;
        private static readonly object Lock = new object();
        private readonly Random _randomProvider;

        public RemoteService(Random randomProvider)
        {
            _randomProvider = randomProvider;
            _logger = (v) => Console.WriteLine(GetType().Name + " " + v);
        }

        public static RemoteService GetRemoteService()
        {
            lock (Lock)
            {
                if (_service == null)
                {
                    lock (Lock)
                    {
                        _service = new RemoteService(new Random());
                    }
                }

                return _service;
            }
        }

        /**
         * Remote function takes a value and multiplies it by 10 taking a random amount of time. Will
         * sometimes return -1. This imitates connectivity issues a client might have to account for.
         *
         * @param value integer value to be multiplied.
         * @return if waitTime is less than {@link RemoteService#THRESHOLD}, it returns value * 10,
         *     otherwise {@link RemoteServiceInterface#FAILURE}.
         */
        public long DoRemoteFunction(int value)
        {

            var waitTime = _randomProvider.Next() * 1000;

            try
            {
                Thread.Sleep(waitTime);
            }
            catch (Exception e)
            {
                _logger("Thread sleep state interrupted");
            }

            return waitTime <= _threshold ? value * 10 : -1;
        }
    }
}