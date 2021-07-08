using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using OutrealXR.HoloMod.Runtime;

namespace OutrealXR.HoloMod.Editor
{
    [CustomEditor(typeof(ModObject))]
    public class ModObjectEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            if (ModRegistry.Instance)
            {
                ModObjectDataAsset supportedMods = ModRegistry.Instance.modObjectDataAsset;
                if (supportedMods != null)
                {


                    SerializedProperty modVars = serializedObject.FindProperty("modVars");
                    SerializedProperty type = serializedObject.FindProperty("type");


                    List<string> choices = new List<string>();
                    foreach (ModObjectData t in supportedMods.SupportedModifiers)
                        choices.Add(t.mName);


                    if (Selection.activeGameObject.tag != supportedMods.targetTag)
                    {
                        EditorGUILayout.HelpBox("The object Tag does not match the TargetTag in the selected ModObjectDataAsset!, Please select add or select the tag", MessageType.Warning);
                    }

                    int newtype = EditorGUILayout.Popup("Modifier Type", type.intValue, choices.ToArray());


                    if (newtype != type.intValue)
                    {
                        type.intValue = newtype;
                        modVars.ClearArray();
                        foreach (ModVar m in supportedMods.SupportedModifiers[type.intValue].modVars)
                        {
                            modVars.InsertArrayElementAtIndex(modVars.arraySize);
                            modVars.GetArrayElementAtIndex(modVars.arraySize - 1).FindPropertyRelative("varName").stringValue = m.varName;
                            modVars.GetArrayElementAtIndex(modVars.arraySize - 1).FindPropertyRelative("value").stringValue = m.value;
                            modVars.GetArrayElementAtIndex(modVars.arraySize - 1).FindPropertyRelative("varType").intValue = (int)m.varType;
                        }
                    }

                    for (int i = 0; i < modVars.arraySize; i++)//supportedMods.SupportedModifiers[currentTarget.type].modVars)
                    {
                        EditorGUILayout.LabelField(modVars.GetArrayElementAtIndex(i).FindPropertyRelative("varName").stringValue);
                        string newValue;
                        switch (modVars.GetArrayElementAtIndex(i).FindPropertyRelative("varType").intValue)
                        {

                            case ((int)ModVar.Type.Bool):
                                newValue = EditorGUILayout.Toggle(modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue == "True").ToString();
                                modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue = newValue;
                                break;

                            case ((int)ModVar.Type.Int):
                                int tempint; System.Int32.TryParse(modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue,out tempint);
                                newValue = EditorGUILayout.IntField(tempint).ToString();
                                modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue = newValue;
                                break;

                            case ((int)ModVar.Type.Float):
                                float tempfloat; float.TryParse(modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue,out tempfloat);
                                newValue = EditorGUILayout.FloatField(tempfloat).ToString();
                                modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue = newValue;
                                break;

                            default:  // ,Float , STR
                                newValue = EditorGUILayout.TextField(modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue);
                                modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue = newValue;
                                break;

                        }

                    }
                    serializedObject.ApplyModifiedProperties();
                    serializedObject.Update();
                }
                else
                {
                    EditorGUILayout.HelpBox("Please choose a ModObjectDataAsset in ModRegistry", MessageType.Warning);
                    if (GUILayout.Button("Go to ModRegistry"))
                    {
                        Selection.objects = new GameObject[] { ModRegistry.Instance.gameObject };
                    }
                }
            }
            else
                EditorGUILayout.HelpBox("Please Create an Object with Mod component", MessageType.Warning);


            DrawDefaultInspector();
            serializedObject.ApplyModifiedProperties();
        }
    }
}