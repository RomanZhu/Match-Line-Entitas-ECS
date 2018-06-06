using System;
using System.Collections.Generic;

[Serializable]
public sealed class ComboPattern
{
    public int Width;
    public int Height;
    public List<GridPosition> Pattern;
    
    public ComboPattern()
    {
        Width = 5;
        Height = 5;
        Pattern = new List<GridPosition>();
    }
}