using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot.Core
{
    public class ArgumentValidationException : Exception
    {
        public ArgumentValidationException(string message) : base(message)
        {
        }
    }
}
