using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ComboDataView : ListDataView<ComboDefinition>
{
    [SerializeField]
    private PatternDataView _view;
    
    protected override string GetHeaderName()
    {
        return "Sorted combos";
    }

    protected override string GetElementName(ComboDefinition element)
    {
        return string.Format("{0} - {1}", element.Name, element.Reward);
    }

    protected override void DrawElementHeader(ComboDefinition element)
    {
        GUILayout.BeginHorizontal(GUI.skin.box);
        GUILayout.Label("Name");
        element.Name = GUILayout.TextField(element.Name);
        GUILayout.Label("Reward");
        element.Reward = EditorGUILayout.IntField("", element.Reward);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }

    protected override void DrawElementBody(ComboDefinition element)
    {
        if (_view == null)
        {
            _view = new PatternDataView {Data = element.PatternVariations};
            _view.InitializeList();
        }
        
        //Will happen after user selects any other element after first
        //AND
        //After context switch (script recompilation)
        //In second case we could maintain selection if we would override hashing
        if (_view.Data != element.PatternVariations)
        {
            _view.SelectedId = -1;
            _view.Data = element.PatternVariations;
            _view.InitializeList();
        }
        
        _view.Draw();
    }
}