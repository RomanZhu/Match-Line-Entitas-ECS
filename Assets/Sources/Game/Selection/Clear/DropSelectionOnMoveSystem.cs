using System.Collections.Generic;
using System.Linq;
using Entitas;

public sealed class DropSelectionOnMoveSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer;
    
    public DropSelectionOnMoveSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher.Selected);
        _buffer = new List<GameEntity>();
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.FieldMoved);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in _group.GetEntities(_buffer))
        {
            entity.isSelected = false;
            entity.RemoveSelectionId();
        }

        _contexts.gameState.ReplaceLastSelected(-1);
        _contexts.gameState.ReplaceMaxSelectedElement(0);
    }
}