using System;
using System.Diagnostics;
using System.Linq;
using IoC;
using System.Collections.Generic;


namespace IoCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string relativPath = Settings.Configuration["Scope"];


            var location = GetAbsolutPath(relativPath);

            Stopwatch stopwatch = new Stopwatch();


            IoCResolver ioc = new IoCResolver(location);
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

        public static string GetAbsolutPath(string relativPath)
        {
            List<string> locationSplit =
               System.Reflection.Assembly.GetExecutingAssembly().Location
               .Split("\\")
               .Reverse()
               .Skip(1)
               .Reverse()
               .ToList();
            //locationSplit.Add(relLocation);
            return $"{String.Join("\\", locationSplit)}\\{relativPath}";
        }
    }

}