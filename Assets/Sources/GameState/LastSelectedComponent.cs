using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class LastSelectedComponent : IComponent
{
    public int value;
}