public static class GameStateExstensions
{
    public static void ResetState(this GameStateContext context)
    {
        context.ReplaceActionCount(0);
        context.ReplaceScore(0);
        context.ReplaceMaxSelectedElement(0);
        context.isGameOver = false;
    }
}