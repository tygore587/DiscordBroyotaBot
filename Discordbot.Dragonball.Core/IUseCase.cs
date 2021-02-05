namespace Discordbot.Dragonball.Core
{
    public interface IUseCase<TResult, TParameters>
    {
        public TResult Execute(TParameters parameters);
    }

    public class NoParameters
    {
    }
}