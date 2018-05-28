using Entitas;

public sealed class MoveSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public MoveSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        int moveCount = 0;

        var size = _contexts.config.mapSize.value;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 1; y < size.y; y++)
            {
                var position = new GridPosition(x, y);
                var candidates = _contexts.game.GetEntitiesWithPosition(position);

                if (candidates.Count > 0)
                {
                    var candidate = candidates.SingleEntity();

                    if (!candidate.isMovable)
                        continue;

                    var targetPosition = new GridPosition(x, y - 1);
                    var targetEntities = _contexts.game.GetEntitiesWithPosition(targetPosition);
                    if (targetEntities.Count == 0)
                    {
                        candidate.ReplacePosition(targetPosition);
                        moveCount++;
                    }
                }
            }
        }

        if (moveCount > 0)
        {
            var e = _contexts.game.CreateEntity();
            e.isFieldMoved = true;
            e.isDestroyed = true;
        }
    }
}