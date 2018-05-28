using UnityEngine;

public interface IInputService
{
    bool IsHolding();
    Vector3 HoldingPosition();
    bool IsStartedHolding();
    float HoldingTime();
    bool IsReleased();

    void Update(float delta);
}