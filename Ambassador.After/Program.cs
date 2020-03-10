using System;

namespace Ambassador.After
{
    class Program
    {
        static void Main(string[] args)
        {
            var host1 = new Client();
            var host2 = new Client();
            host1.UseService(12);
            host2.UseService(73);
        }
    }
}
