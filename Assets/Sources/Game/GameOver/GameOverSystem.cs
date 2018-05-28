using System.Collections.Generic;
using Entitas;

public sealed class GameOverSystem : ReactiveSystem<GameStateEntity>
{
    private readonly Contexts _contexts;

    public GameOverSystem(Contexts contexts) : base(contexts.gameState)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
    {
        return context.CreateCollector(GameStateMatcher.ActionCount);
    }

    protected override bool Filter(GameStateEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameStateEntity> entities)
    {
        if (_contexts.gameState.actionCount.value >= _contexts.config.maxActionCount.value)
        {
            _contexts.gameState.isGameOver = true;
        }
    }
}