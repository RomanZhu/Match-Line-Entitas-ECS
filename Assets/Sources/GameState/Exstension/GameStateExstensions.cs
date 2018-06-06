public static class GameStateExstensions
{
    public static void ResetState(this GameStateContext context)
    {
        context.ReplaceLastSelected(-1);
        context.ReplaceActionCount(0);
        context.ReplaceScore(0);
        context.ReplaceMaxSelectedElement(0);
        context.isGameOver = false;
    }
}