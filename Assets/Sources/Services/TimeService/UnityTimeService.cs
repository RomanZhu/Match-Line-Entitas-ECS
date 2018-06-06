using UnityEngine;

public sealed class UnityTimeService : Service, ITimeService
{
    public UnityTimeService(Contexts contexts) : base(contexts)
    {
    }

    public float DeltaTime()
    {
        return Time.deltaTime;
    }

    public float RealtimeSinceStartup()
    {
        return Time.realtimeSinceStartup;
    }
}