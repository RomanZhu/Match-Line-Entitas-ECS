public class GameSystems : Feature
{
    public GameSystems(Contexts contexts, Services services)
    {
        Add(new FillAllElementsSystem(contexts, services));
        Add(new AddElementsSystem(contexts, services));
        Add(new ViewSystem(contexts, services));

        Add(new AddSelectionSystem(contexts));
        Add(new UnselectionSystem(contexts));

        Add(new MarkMatchedSystem(contexts));
        Add(new ExplosionSystem(contexts));

        Add(new ComboDetectionSystem(contexts));
        Add(new RewardSystems(contexts, services));

        Add(new ActionCounterSystem(contexts));
        Add(new GameOverSystem(contexts));

        Add(new RemoveMatchedSystem(contexts));
        Add(new DropSelectionSystem(contexts));

        Add(new MoveSystem(contexts));
        Add(new DropSelectionOnMoveSystem(contexts));

        Add(new GameRestartSystem(contexts));
        
        Add(new DestroyEntitySystem(contexts));
    }
}