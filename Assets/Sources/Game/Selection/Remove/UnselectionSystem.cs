using System;
using System.Collections.Generic;
using Entitas;

public sealed class UnselectionSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts _contexts;
    
    public UnselectionSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
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

        var targetEntity = _contexts.game.GetEntityWithSelectionId(targetSelectionId);
        var position = _contexts.input.pointerHoldingPosition.value.ToGridPosition();

        if (position.Equals(targetEntity.position.value))
        {
            var lastSelectedEntity = _contexts.game.GetEntityWithId(_contexts.gameState.lastSelected.value);
            lastSelectedEntity.isSelected = false;
            lastSelectedEntity.RemoveSelectionId();
            
            _contexts.gameState.ReplaceLastSelected(targetEntity.id.value);
            _contexts.gameState.ReplaceMaxSelectedElement(targetSelectionId);
        }
    }
}