using ViewModel.Core;

namespace Service
{
    public class UserSession
    {
        public static UserModel User { get; set; }

        // db connection
        public static string Database { get; set; }

    }
}
