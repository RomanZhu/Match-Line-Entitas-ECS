using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(true, EventType.Added)]
[Event(true, EventType.Removed)]
public sealed class SelectedComponent : IComponent
{
}