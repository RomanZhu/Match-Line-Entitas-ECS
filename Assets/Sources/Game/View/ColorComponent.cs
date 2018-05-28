using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
[Event(true)]
public sealed class ColorComponent : IComponent
{
    public Color value;
}