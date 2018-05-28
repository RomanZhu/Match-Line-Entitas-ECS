using System.Collections.Generic;
using Entitas;

public sealed class RewardEmitterSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public RewardEmitterSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Matched.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMatched;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var table = _contexts.config.scoringTable.value;
        var scoreId = entities.Count;
        scoreId--;

        if (scoreId >= table.Count)
            scoreId = table.Count - 1;

        var reward = table[scoreId];

        var e = _contexts.game.CreateEntity();
        e.AddReward(reward);
    }
}