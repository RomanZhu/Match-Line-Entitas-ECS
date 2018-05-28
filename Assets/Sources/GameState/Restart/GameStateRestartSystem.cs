using System.Collections.Generic;
using Entitas;

public sealed class GameStateRestartSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts _contexts;

    public GameStateRestartSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Restart.Added());
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        _contexts.gameState.ResetState();
    }
}