using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input]
[Unique]
public sealed class PointerHoldingPositionComponent : IComponent
{
    public Vector3 value;
}