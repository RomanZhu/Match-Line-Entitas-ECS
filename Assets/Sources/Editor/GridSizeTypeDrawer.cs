using System;
using Entitas.VisualDebugging.Unity.Editor;
using UnityEditor;

public class GridSizeTypeDrawer : ITypeDrawer {

    public bool HandlesType(Type type) {
        return type == typeof(GridSize);
    }

    public object DrawAndGetNewValue(Type memberType, string memberName, object value, object target) {
        var vector = (GridSize)value;
        vector.x = EditorGUILayout.IntField("x", vector.x);
        vector.y = EditorGUILayout.IntField("y", vector.y);
        return vector;
    }
}