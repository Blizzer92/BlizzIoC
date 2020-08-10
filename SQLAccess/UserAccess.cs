using Interfaces;

namespace SQLAccess
{
    public class UserAccess : IUserAccess
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