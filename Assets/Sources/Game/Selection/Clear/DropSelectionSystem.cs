using System.Collections.Generic;
using Entitas;

public sealed class DropSelectionSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer;

    public DropSelectionSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher.Selected);
        _buffer = new List<GameEntity>();
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.PointerReleased);
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if (_contexts.input.isPointerHolding)
            return;

        foreach (var entity in _group.GetEntities(_buffer))
        {
            entity.isSelected = false;
            entity.RemoveSelectionId();
        }

        _contexts.gameState.ReplaceLastSelected(-1);
        _contexts.gameState.ReplaceMaxSelectedElement(0);
    }
}