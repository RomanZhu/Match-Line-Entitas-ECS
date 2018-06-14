using System.Collections.Generic;
using Entitas;

public sealed class GameRestartSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer;

    public GameRestartSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.Element);
        _buffer = new List<GameEntity>();
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
        foreach (var entity in _group.GetEntities(_buffer))
        {
            entity.isDestroyed = true;
        }

        var e = _contexts.game.CreateEntity();
        e.isRestartHappened = true;
    }
}