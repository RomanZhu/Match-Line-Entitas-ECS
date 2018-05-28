using System.Collections.Generic;
using Entitas;

public sealed class ExplosionSystem : ReactiveSystem<GameEntity>
{
    private readonly IGroup<GameEntity> _exsplosives;
    private readonly List<GameEntity> _buffer;
    private readonly List<GridPosition> _positionBuffer;

    public ExplosionSystem(Contexts contexts) : base(contexts.game)
    {
        _exsplosives = contexts.game.GetGroup(GameMatcher.Exsplosive);
        _buffer = new List<GameEntity>();
        _positionBuffer = new List<GridPosition>();
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Matched.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var exsplosiveEntity in _exsplosives.GetEntities(_buffer))
        {
            bool found = false;

            var positions = exsplosiveEntity.position.value.GetNeighbours(_positionBuffer);
            foreach (var position in positions)
            {
                foreach (var matchedEntity in entities)
                {
                    if (matchedEntity.hasPosition)
                    {
                        if (position.Equals(matchedEntity.position.value))
                        {
                            found = true;
                            exsplosiveEntity.isMatched = true;
                            break;
                        }
                    }
                }

                if (found)
                    break;
            }
        }
    }
}