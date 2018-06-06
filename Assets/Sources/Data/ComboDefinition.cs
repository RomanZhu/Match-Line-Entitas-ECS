using System;
using System.Collections.Generic;

[Serializable]
public sealed class ComboDefinition
{
    public string Name;
    
    public List<ComboPattern> PatternVariations;

    public int Reward;

    public ComboDefinition()
    {
        Name = "Untitled";
        PatternVariations = new List<ComboPattern>();
        Reward = 100;
    }
}