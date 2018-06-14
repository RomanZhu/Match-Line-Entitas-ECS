using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class FillAllElementsSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly ElementService _elementService;

    public FillAllElementsSystem(Contexts contexts, Services services) : base(contexts.game)
    {
        _contexts = contexts;
        _elementService = services.ElementService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.RestartHappened.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        Fill();

        foreach (var entity in entities)
        {
            entity.isDestroyed = true;
        }
    }

    public void Initialize()
    {
        Fill();
    }

    private void Fill()
    {
        var size = _contexts.config.mapSize.value;

        for (int row = 0; row < size.y; row++)
        {
            for (int column = 0; column < size.x; column++)
            {
                float random = Random.Range(0f, 1f);
                if (random < 0.1f)
                {
                    if (random < 0.05f)
                    {
                        if (random < 0.005f)
                        {
                            _elementService.CreateExsplosiveBlock(new GridPosition(column, row));
                        }
                        else
                        {
                            _elementService.CreateNotMovableBlock(new GridPosition(column, row));
                        }
                    }
                    else
                    {
                        _elementService.CreateMovableBlock(new GridPosition(column, row));
                    }
                }
                else
                {
                    _elementService.CreateRandomElement(new GridPosition(column, row));
                }
            }
        }
    }
}