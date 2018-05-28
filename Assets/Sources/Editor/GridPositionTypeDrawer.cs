using System;
using Entitas.VisualDebugging.Unity.Editor;
using UnityEditor;

public class GridPositionTypeDrawer : ITypeDrawer {

    public bool HandlesType(Type type) {
        return type == typeof(GridPosition);
    }

    public object DrawAndGetNewValue(Type memberType, string memberName, object value, object target) {
        var vector = (GridPosition)value;
        vector.x = EditorGUILayout.IntField("x", vector.x);
        vector.y = EditorGUILayout.IntField("y", vector.y);
        return vector;
    }
}