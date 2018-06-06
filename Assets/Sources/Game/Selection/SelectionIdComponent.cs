using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class SelectionIdComponent : IComponent
{
    [PrimaryEntityIndex] public int value;
}