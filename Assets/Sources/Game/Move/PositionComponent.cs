using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
[Event(true)]
public sealed class PositionComponent : IComponent
{
    [EntityIndex] public GridPosition value;
}