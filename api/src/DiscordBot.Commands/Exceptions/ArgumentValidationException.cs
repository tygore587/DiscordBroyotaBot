using System;

namespace DiscordBot.Commands.Exceptions
{
    public class ArgumentValidationException : Exception
    {
        public ArgumentValidationException(string message) : base(message)
        {
        }
    }
}