public class InputSystems : Feature
{
    public InputSystems(Contexts contexts, Services services)
    {
        Add(new UpdateTimeSystem(contexts, services));
        Add(new UpdateInputSystem(contexts, services));
    }
}