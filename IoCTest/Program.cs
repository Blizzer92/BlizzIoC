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
            string test = Settings.Settings.Configuration["IDataAccsses"];

            User user = IoC.IoC.Resolve<User>(test);

            Console.WriteLine(user.GetUserName());
            Console.ReadKey();
        }
    }

}