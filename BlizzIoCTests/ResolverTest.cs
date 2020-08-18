using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using BlizzIoC;
using NUnit.Framework;

namespace BlizzIoCTests
{
    public class Tests
    {
        private IoCResolver ioc;
        
        [SetUp]
        public void Setup()
        {
            string test = Settings.Configuration["Scope"];
            string path = GetAbsolutPath(test);


            this.ioc = new IoCResolver(path);
        }

        [Test]
        public void UserTest()
        {
            User user = this.ioc.Resolve<User>();

            if (user.GetUserName() == "Peter SQL" && user.GetUserMoney() == "20€")
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        public static string GetAbsolutPath(string relativPath)
        {
            List<string> locationSplit = new List<string>();


            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                locationSplit = System.Reflection.Assembly.GetExecutingAssembly().Location
                    .Split("\\")
                    .Reverse()
                    .Reverse()
                    .ToList();
            }
            else
            {
                locationSplit = System.Reflection.Assembly.GetExecutingAssembly().Location
                    .Split("\\")
                    .Reverse()
                    .Skip(1)
                    .Reverse()
                    .ToList();
            }

            string path = $"{String.Join("\\", locationSplit)}\\{relativPath}";
            return path;
        }

    }
}