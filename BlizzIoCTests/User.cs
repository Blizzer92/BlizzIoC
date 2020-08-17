using Interfaces;

namespace BlizzIoCTests
{
    public class User
    {
        private IUserAccess access;
        private IMoneyAccess sd;


        public User(IUserAccess dbAccess, IMoneyAccess money)
        {
            this.access = dbAccess;
            sd = money;
        }


        public string GetUserName()
        {
            return this.access.GetUserName();
        }

        public string GetUserMoney()
        {
            return this.sd.GetMoney();
        }
    }
}