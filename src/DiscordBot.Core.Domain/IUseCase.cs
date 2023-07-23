namespace DiscordBot.Core.Domain
{
    public interface IUseCase<out TResult, in TParameters>
    {
        public TResult Execute(TParameters parameters);
    }

    public class NoParameters
    {
    }
}