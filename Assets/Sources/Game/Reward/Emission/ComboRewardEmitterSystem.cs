using System.Collections.Generic;
using Entitas;

public sealed class ComboRewardEmitterSystem : ReactiveSystem<GameEntity>
{

    private readonly Contexts _contexts;

    public ComboRewardEmitterSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Combo);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCombo;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var table = _contexts.config.comboScoringTable.value;
        
        foreach (var entity in entities)
        {
            var reward = table[entity.combo.value];

            var e = _contexts.game.CreateEntity();
            e.AddReward(reward);

            entity.isDestroyed = true;
        }
    }
}