using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
[Event(true)]
public sealed class PositionComponent : IComponent
{
    [PrimaryEntityIndex] public GridPosition value;
}