using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class ComboScoringTableComponent : IComponent
{
    public Dictionary<ComboType, int> value;
}