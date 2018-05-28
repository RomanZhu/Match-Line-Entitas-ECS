public class RootSystems : Feature
{
    public RootSystems(Contexts contexts, Services services)
    {
        Add(new InputSystems(contexts, services));

        Add(new GameStateSystems(contexts, services));
        Add(new GameStateEventSystems(contexts));

        Add(new GameSystems(contexts, services));
        Add(new GameEventSystems(contexts));
    }
}