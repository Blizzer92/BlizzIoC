using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Interfaces;

namespace IoCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = Settings.Settings.Configuration["Scope"];

            User user = IoC.IoC.Resolve<User>(test);
            Money money = IoC.IoC.Resolve<Money>(test);
            
            
            Console.WriteLine(user.GetUserName());
            Console.WriteLine(money.GetMoney());
            Console.ReadKey();
        }
    }

}