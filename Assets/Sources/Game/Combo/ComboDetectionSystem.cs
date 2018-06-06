using System.Collections.Generic;
using Entitas;

public sealed class ComboDetectionSystem : ReactiveSystem<GameEntity>
{

    private readonly Contexts _contexts;
    private readonly Dictionary<int, GameEntity> _buffer;
    private readonly List<GameEntity> _currentBuffer;

    public ComboDetectionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _buffer = new Dictionary<int, GameEntity>(64);
        _currentBuffer = new List<GameEntity>(64);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Matched.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMatched && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var definitions = _contexts.config.comboDefinitions.value;
        var size = _contexts.config.mapSize.value;

        var elementCount = entities.Count;
        
        foreach (var entity in entities)
        {
            var index = entity.position.value.ToIndex(size);
            _buffer.Add(index, entity);
        }

        for (var id = 0; id < definitions.Definitions.Count; id++)
        {
            var definition = definitions.Definitions[id];
            foreach (var variation in definition.PatternVariations)
            {
                if (elementCount < variation.Pattern.Count)
                    continue;

                var xMax = size.x - (variation.Width - 1);
                var yMax = size.y - (variation.Height - 1);

                for (var x = 0; x < xMax; x++)
                {
                    for (var y = 0; y < yMax; y++)
                    {
                        var success = DetectPattern(variation, x, y, size);

                        if (success)
                        {
                            foreach (var entity in _currentBuffer)
                            {
                                entity.isInCombo = true;
                                
                                var index = entity.position.value.ToIndex(size);
                                _buffer.Remove(index);
                            }

                            EmitCombo(id);

                            elementCount -= _currentBuffer.Count;
                        }

                        _currentBuffer.Clear();
                    }
                }
            }
        }

        foreach (var entity in entities)
        {
            var index = entity.position.value.ToIndex(size);
            _buffer.Remove(index);
        }
    }

    private bool DetectPattern(ComboPattern variation, int x, int y, GridSize size)
    {
        var fail = false;
        foreach (var position in variation.Pattern)
        {
            var isCellEven = x % 2 == 0;
            var isPositionEven = (x + position.x) % 2 == 0;

            var addition = 0;

            if (!isCellEven && isPositionEven)
                addition = 1;
            
            var index = new GridPosition(x + position.x, y + position.y + addition).ToIndex(size);

            GameEntity e;

            if (_buffer.TryGetValue(index, out e))
            {
                _currentBuffer.Add(e);
            }
            else
            {
                fail = true;
                break;
            }
        }

        return !fail;
    }

    private void EmitCombo(int id)
    {
        var e = _contexts.game.CreateEntity();
        e.AddCombo(id);
        e.isDestroyed = true;
    }
}