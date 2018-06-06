using System.Collections.Generic;
using Entitas;
using UnityEngine;

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
        var definitions = _contexts.config.comboDefinitions.value;

        foreach (var entity in entities)
        {
            var defenition = definitions.Definitions[entity.combo.value];
            
            var e = _contexts.game.CreateEntity();
            e.AddReward(defenition.Reward);
        }
    }
}