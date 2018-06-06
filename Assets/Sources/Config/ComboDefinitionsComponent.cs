using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class ComboDefinitionsComponent : IComponent
{
    public ComboDefinitions value;
}