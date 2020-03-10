
using System;
using System.IO;
using System.Threading;
using System.Threading.Channels;

namespace Ambassador.After
{
    public class ServiceAmbassador : IRemoteServiceInterface
    {
        private static Action<string> _logger;
        private static readonly int _retries = 3;
        private static readonly int _delayMs = 3000;

        public ServiceAmbassador()
        {
            _logger = (v) => Console.Write(GetType().Name + " " + v);
        }

        public long DoRemoteFunction(int value)
        {
            return SafeCall(value);
        }

        private long CheckLatency(int value)
        {
            var startTime = DateTime.Now.Millisecond;
            var result = RemoteService.GetRemoteService().DoRemoteFunction(value);
            var timeTaken = DateTime.Now.Millisecond - startTime;

            _logger("Time taken (ms): " + timeTaken);
            return result;
        }

        private long SafeCall(int value)
        {
            var retries = 0;
            var result = (long)-1;

            for (int i = 0; i < _retries; i++)
            {
                if (retries >= _retries)
                {
                    return -1;
                }

                if ((result = CheckLatency(value)) == -1)
                {
                    _logger("Failed to reach remote: (" + (i + 1) + ")");
                    retries++;
                    try
                    {
                        Thread.Sleep(_delayMs);
                    }
                    catch (Exception e)
                    {
                        _logger("Thread sleep state interrupted");
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
