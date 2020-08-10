using Interfaces;

namespace IoCTest
{
    public class User
    {
        private IUserAccess access;


        public User(IUserAccess dbAccess)
        {
            this.access = dbAccess;
        }


        public string GetUserName()
        {
            return this.access.GetUserName();
        }
    }
}