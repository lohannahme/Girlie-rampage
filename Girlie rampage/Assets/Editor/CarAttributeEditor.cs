using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(CarAttribute), true)]
public class CarAttributeEditor : PropertyDrawer
{
    // SerializedProperty _useCurveProperty;
    // SerializedProperty _keyProperty;
    // SerializedProperty _curveProperty;
    // SerializedProperty _floatProperty;
    // void OnEnable()
    // {
    //     _keyProperty = serializedObject.FindProperty("_key");
    //     _useCurveProperty = serializedObject.FindProperty("_useCurve");
    //     _curveProperty = serializedObject.FindProperty("_curve");
    //     _floatProperty = serializedObject.FindProperty("_value");
    // }

    // public override void OnInspectorGUI()
    // {
    //     serializedObject.Update();

    //     EditorGUILayout.PropertyField(_keyProperty);
    //     EditorGUILayout.PropertyField(_useCurveProperty);

    //     if (_useCurveProperty.boolValue)
    //     {
    //         EditorGUILayout.PropertyField(_curveProperty);
    //     }
    //     else
    //     {
    //         EditorGUILayout.PropertyField(_floatProperty);
    //     }

    //     serializedObject.ApplyModifiedProperties();

    // }
    private bool isUnFolded;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // draw folder for the entire class
        isUnFolded = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), isUnFolded, label);
        // go to the next line
        position.y += EditorGUIUtility.singleLineHeight;

        // only draw the rest if unfolded
        if (isUnFolded)
        {
            // draw fields indented
            EditorGUI.indentLevel++;

            // similar to before get the according serialized properties for the fields
            SerializedProperty _keyProperty = property.FindPropertyRelative("_key");
            SerializedProperty _useCurveProperty = property.FindPropertyRelative("_useCurve");
            SerializedProperty _curveProperty = property.FindPropertyRelative("_curve");
            SerializedProperty _floatProperty = property.FindPropertyRelative("_value");


            // Draw A field
            EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), _keyProperty);
            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), _useCurveProperty);
            position.y += EditorGUIUtility.singleLineHeight;

            if (_useCurveProperty.boolValue)
            {
                // Draw B field
                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), _curveProperty);
            }
            else
            {
                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), _floatProperty);
            }

            // reset indentation
            EditorGUI.indentLevel--;
        }
    }

    // IMPORTANT you have to implement this since your new property is
    // higher then 1 single line
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // default is 1 single line
        var height = isUnFolded ? 4 : 1;
        // if unfolded at least 1 line more, if a is true 2 lines more
        // if (isUnFolded)
        // {
        //     height += (property.FindPropertyRelative("A").boolValue ? 2 : 1);
        // }

        return height * EditorGUIUtility.singleLineHeight;
    }
}