using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Threading;

namespace ProxyList
{
    class Program
    {
        static void Main(string[] args)
        {
            CountdownEvent handler = new CountdownEvent(100);
            for (int i = 0; i < 100; i++)
            {
                var j = i;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    Console.WriteLine("thread " + j);
                    Thread.Sleep(1000);   //wait 1 seconds to do something
                    handler.Signal();
                });
            }

            handler.Wait();
            Console.WriteLine("finished");
            Console.ReadKey();
        }
    }
}
