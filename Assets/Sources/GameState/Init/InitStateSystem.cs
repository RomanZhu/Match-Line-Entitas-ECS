using Entitas;

public sealed class InitStateSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public InitStateSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.gameState.ResetState();
    }
}