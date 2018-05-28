using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class ExsplosiveScoringTableComponent : IComponent
{
    public List<int> value;
}