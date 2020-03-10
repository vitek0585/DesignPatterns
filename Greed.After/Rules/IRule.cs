namespace Greed.After.Rules
{
    public interface IRule
    {
        ScoreResult Eval(int[] dice);
    }
}