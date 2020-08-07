using Interfaces;

namespace IoCTest
{
    public class User
    {
        private IDataAccsses access;


        public User(IDataAccsses dbAccess)
        {
            this.access = dbAccess;
        }


        public string GetUserName()
        {
            return this.access.GetUserName();
        }
    }
}