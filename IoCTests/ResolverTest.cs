using IoC;
using IoCTest;
using NUnit.Framework;

namespace IoCTests
{
    public class Tests
    {
        private IoCResolver ioc;
        
        [SetUp]
        public void Setup()
        {
            string test = Settings.Configuration["Scope"];
            this.ioc = new IoCResolver(test);
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
    }
}