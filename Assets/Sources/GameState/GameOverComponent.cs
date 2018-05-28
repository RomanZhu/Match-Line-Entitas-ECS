using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(false, EventType.Added)]
[Event(false, EventType.Removed)]
public sealed class GameOverComponent : IComponent
{
}