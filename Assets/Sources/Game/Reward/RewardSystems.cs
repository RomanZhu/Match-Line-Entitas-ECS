public class RewardSystems : Feature
{
    public RewardSystems(Contexts contexts, Services services)
    {
        Add(new RewardEmitterSystem(contexts));
        Add(new ExsplosiveRewardEmitterSystem(contexts));
        Add(new ComboRewardEmitterSystem(contexts));

        Add(new ApplyRewardSystem(contexts));
    }
}