using System.Collections.Generic;
using Entitas;

public sealed class AddSelectionSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer;
    
    public AddSelectionSystem(Contexts contexts) : base(contexts.input)
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

        var position = _contexts.input.pointerHoldingPosition.value.ToGridPosition();

        var horizontalBounded = position.x >= 0 && position.x < _contexts.config.mapSize.value.x;
        var verticalBounded = position.y >= 0 && position.y < _contexts.config.mapSize.value.y;

        if (horizontalBounded && verticalBounded)
        {
            var entitiesUnderPointer = _contexts.game.GetEntitiesWithPosition(position);
            if (entitiesUnderPointer.Count == 0)
                return;

            var entityUnderPointer = entitiesUnderPointer.SingleEntity();

            if (entityUnderPointer.isBlock)
                return;

            if (entityUnderPointer.isSelected)
                return;

            var lastSelectedEntities = _group.GetEntities(_buffer);
            if (lastSelectedEntities.Count == 0)
            {
                entityUnderPointer.isSelected = true;
                entityUnderPointer.isLastSelected = true;
                entityUnderPointer.ReplaceSelectionId(0);

                _contexts.gameState.ReplaceMaxSelectedElement(0);
            }
            else
            {
                var lastSelected = lastSelectedEntities.SingleEntity();
                if (lastSelected.hasElementType && entityUnderPointer.hasElementType)
                {
                    if (lastSelected.elementType.value == entityUnderPointer.elementType.value)
                    {
                        if (GridPosition.Distance(lastSelected.position.value, entityUnderPointer.position.value) <
                            1.25f)
                        {
                            var selectionId = _contexts.gameState.maxSelectedElement.value;
                            selectionId++;

                            lastSelected.isLastSelected = false;
                            entityUnderPointer.isSelected = true;
                            entityUnderPointer.isLastSelected = true;
                            entityUnderPointer.ReplaceSelectionId(selectionId);

                            _contexts.gameState.ReplaceMaxSelectedElement(selectionId);
                        }
                    }
                }
            }
        }
    }
}