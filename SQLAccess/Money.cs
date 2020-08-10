using Interfaces;

namespace SQLAccess
{
    public class Money : IMoneyAccess
    {
        public string GetMoney()
        {
            return "20€";
        }
    }
}