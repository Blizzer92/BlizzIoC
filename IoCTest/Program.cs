using System;
using IoC;

namespace IoCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = Settings.Configuration["Scope"];
            
            IoCResolver ioc = new IoCResolver(test);
            User user = ioc.Resolve<User>();
            Money money = ioc.Resolve<Money>();

            Console.WriteLine(user.GetUserName());
            Console.WriteLine(money.GetMoney());
            Console.ReadKey();
        }
    }

}