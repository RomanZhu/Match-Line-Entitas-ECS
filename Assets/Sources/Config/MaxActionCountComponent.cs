using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
[Event(false)]
public sealed class MaxActionCountComponent : IComponent
{
    public int value;
}