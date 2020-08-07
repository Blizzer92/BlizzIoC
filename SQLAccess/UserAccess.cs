using Interfaces;

namespace SQLAccess
{
    public class UserAccess : IDataAccsses
    {
        public UserAccess()
        {

        }
        public string GetUserName()
        {
            return "Peter SQL";
        }
    }
}