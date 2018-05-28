public class GameStateSystems : Feature
{
    public GameStateSystems(Contexts contexts, Services services)
    {
        Add(new InitStateSystem(contexts));
        Add(new GameStateRestartSystem(contexts));
    }
}