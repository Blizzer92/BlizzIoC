using System;
using System.Diagnostics;
using IoC;

namespace IoCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = Settings.Configuration["Scope"];
            
            Stopwatch stopwatch = new Stopwatch();


            IoCResolver ioc = new IoCResolver(test);
            stopwatch.Start();
            User user = ioc.Resolve<User>();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            User user2 = ioc.Resolve<User>(true);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);


            Console.WriteLine(user.GetUserName());
            Console.ReadKey();
        }
    }

}