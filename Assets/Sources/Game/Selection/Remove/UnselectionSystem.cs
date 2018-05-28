using System;
using System.Collections.Generic;
using Entitas;

public sealed class UnselectionSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer;
    
    public UnselectionSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher.LastSelected);
        _buffer = new List<GameEntity>();
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.PointerHoldingPosition);
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if (!_contexts.input.isPointerHolding)
            return;

        var targetSelectionId = _contexts.gameState.maxSelectedElement.value - 1;

        if (targetSelectionId < 0)
            return;

        var targetEntity = _contexts.game.GetEntitiesWithSelectionId(targetSelectionId).SingleEntity();
        var position = _contexts.input.pointerHoldingPosition.value.ToGridPosition();

        if (position.Equals(targetEntity.position.value))
        {
            var lastSelectedEntity = _group.GetEntities(_buffer).SingleEntity();
            lastSelectedEntity.isLastSelected = false;
            lastSelectedEntity.isSelected = false;
            lastSelectedEntity.RemoveSelectionId();

            targetEntity.isLastSelected = true;

            _contexts.gameState.ReplaceMaxSelectedElement(targetSelectionId);
        }
    }
}