using System;

namespace Discordbot.Core
{
    public class ArgumentValidationException : Exception
    {
        public ArgumentValidationException(string message) : base(message)
        {
        }
    }
}