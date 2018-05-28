using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
[Unique]
public sealed class PointerHoldingTimeComponent : IComponent
{
    public float value;
}