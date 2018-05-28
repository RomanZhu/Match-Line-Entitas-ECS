using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class SelectionIdComponent : IComponent
{
    [EntityIndex] public int value;
}