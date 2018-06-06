using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class PatternDataView : ListDataView<ComboPattern>
{
    private const float Size = 30f;
    private const float HalfSize = 15f;
    private const float Offset = 5f;
    
    protected override string GetHeaderName()
    {
        return "Pattern variations";
    }

    protected override string GetElementName(ComboPattern element)
    {
        return string.Format("{0} points ({1}:{2})", element.Pattern.Count, element.Width, element.Height);
    }

    protected override void DrawElementHeader(ComboPattern element)
    {
        GUILayout.BeginHorizontal(GUI.skin.box);
        GUILayout.Label("Width");
        element.Width = EditorGUILayout.IntField("", element.Width, GUILayout.Width(20f));
        GUILayout.Label("Height");
        element.Height = EditorGUILayout.IntField("", element.Height, GUILayout.Width(20f));
        GUILayout.FlexibleSpace();
        if (element.Width < 1) element.Width = 1;
        if (element.Height < 1) element.Height = 1;
        for (var i = 0; i < element.Pattern.Count; i++)
        {
            var position = element.Pattern[i];
            if (position.x > element.Width - 1 || position.y > element.Height - 1)
            {
                element.Pattern.Remove(position);
            }
        }

        GUILayout.EndHorizontal();
    }

    protected override void DrawElementBody(ComboPattern element)
    {
        GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
        for (int x = 0; x < element.Width; x++)
        {
            GUILayout.BeginVertical(GUILayout.Width(Size));
            if(x%2==0)
                GUILayout.Space(HalfSize+Offset);
            
            for (int y = element.Height - 1; y >= 0; y--)
            {
                DrawCell(element, x, y);
                GUILayout.Space(Offset);
            }
            GUILayout.EndVertical();
            GUILayout.Space(Offset);
        }
        GUILayout.EndHorizontal();
    }

    private void DrawCell(ComboPattern element, int x, int y)
    {
        var color = GUI.color;
        var pos = new GridPosition(x, y);
        var contains = element.Pattern.Contains(pos);
        
        if(contains)
            GUI.color = Color.green;
        
        if (GUILayout.Button(contains?"-":"+", GUILayout.Width(Size), GUILayout.Height(Size)))
        {
            if (contains)
            {
                element.Pattern.Remove(pos);
            }
            else
            {
                element.Pattern.Add(pos);
            }
        }

        GUI.color = color;
    }
}