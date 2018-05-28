using System.Collections.Generic;
using Entitas;

public sealed class Line5ComboSystem : ReactiveSystem<GameEntity>
{
    //rivate readonly Contexts _contexts;
    
    public Line5ComboSystem(Contexts contexts) : base(contexts.game)
    {
        //_contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Matched);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMatched && !entity.isInCombo;
    }

    protected override void Execute(List<GameEntity> entities)
    {
//        Detect sequentially all combos and mark corresponding entities as "InCombo"
//        Then:
//        foreach(var figure in detectedFigures)
//        {
//            var e = _contexts.game.CreateEntity();
//            e.AddCombo(ComboType.Line5);
//        }
    }
}