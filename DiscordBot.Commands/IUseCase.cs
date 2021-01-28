using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Commands
{
    public interface IUseCase<TResult, TParameters>
    {
        public TResult Execute(TParameters parameters);
    }



    public class NoParameters
    {

    }
}
