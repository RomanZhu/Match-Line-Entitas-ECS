using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(false)]
public sealed class ActionCountComponent : IComponent
{
    public int value;
}