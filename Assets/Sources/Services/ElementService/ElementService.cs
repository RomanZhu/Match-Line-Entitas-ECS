using UnityEngine;

public sealed class ElementService : Service
{
    private int _entityCounter;

    public ElementService(Contexts contexts) : base(contexts)
    {
        _entityCounter = 0;
    }

    public void CreateRandomElement(GridPosition position)
    {
        var maxType = Mathf.Clamp(_contexts.config.typeCount.value - 1, 1, 100);
        var randomType = Random.Range(0, maxType + 1);
        var normalizedType = Mathf.InverseLerp(0, maxType, randomType);

        var entity = _contexts.game.CreateEntity();
        entity.isElement = true;
        entity.AddId(_entityCounter);
        entity.isMovable = true;
        entity.AddElementType(randomType);
        entity.AddAsset("Element");
        entity.AddColor(new Color(normalizedType, normalizedType, normalizedType));
        entity.AddPosition(position);

        _entityCounter++;
    }

    public void CreateMovableBlock(GridPosition position)
    {
        var entity = _contexts.game.CreateEntity();
        entity.isElement = true;
        entity.AddId(_entityCounter);
        entity.isMovable = true;
        entity.AddAsset("Block");
        entity.AddPosition(position);
        entity.isBlock = true;

        _entityCounter++;
    }

    public void CreateNotMovableBlock(GridPosition position)
    {
        var entity = _contexts.game.CreateEntity();
        entity.isElement = true;
        entity.AddId(_entityCounter);
        entity.AddAsset("NotMovableBlock");
        entity.AddPosition(position);
        entity.isBlock = true;

        _entityCounter++;
    }

    public void CreateExsplosiveBlock(GridPosition position)
    {
        var entity = _contexts.game.CreateEntity();
        entity.isElement = true;
        entity.AddId(_entityCounter);
        entity.AddAsset("ExsplosiveBlock");
        entity.AddPosition(position);
        entity.isExsplosive = true;
        entity.isBlock = true;

        _entityCounter++;
    }

    protected override void DropState()
    {
        _entityCounter = 0;
    }
}