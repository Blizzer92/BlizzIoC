using Interfaces;

namespace IoCTest
{
    public class Money : IMoneyAccess
    {
        
        private IMoneyAccess access;

        public Money(IMoneyAccess moneyAccess)
        {
            this.access = moneyAccess;
        }
        
        public string GetMoney()
        {
            return this.access.GetMoney();
        }
    }
}