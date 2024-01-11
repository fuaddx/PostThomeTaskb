using System.Runtime.Serialization;

namespace TwitFriday
{
    public class AppUserCreatedFailedException : Exception
    {
        public AppUserCreatedFailedException()
        {
        }

        public AppUserCreatedFailedException(string? message) : base(message)
        {
        }
    }
}