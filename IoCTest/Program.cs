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
            Assembly dll = Assembly.LoadFile(@"C:\Users\svenj\source\repos\IoCTest\IoCTest\bin\Debug\netcoreapp3.1\SQLAccess.dll");
            string typeNameNew = (dll?.DefinedTypes).FirstOrDefault(x => x.FullName != null && x.FullName.Contains("UserAccess"))?.FullName;
            Type viewType = dll?.GetType(typeNameNew ?? string.Empty);
            IDataAccsses dataAccsses = (IDataAccsses)Activator.CreateInstance(viewType!);

            User user = new User(dataAccsses);

            Console.WriteLine(user.GetUserName());
            Console.ReadKey();
        }
    }

}