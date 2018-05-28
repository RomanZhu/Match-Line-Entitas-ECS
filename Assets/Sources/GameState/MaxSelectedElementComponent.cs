using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class MaxSelectedElementComponent : IComponent
{
    public int value;
}