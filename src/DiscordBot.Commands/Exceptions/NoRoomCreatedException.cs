using System;

namespace DiscordBot.Commands.Exceptions
{
    public class NoRoomCreatedException : Exception
    {
        public NoRoomCreatedException(string? message) : base(message)
        {
        }
    }
}