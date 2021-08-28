using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using OutrealXR.HoloMod.Runtime;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace OutrealXR.HoloMod.Editor
{
    [CustomEditor(typeof(ModObject))]
    public class ModObjectEditor : UnityEditor.Editor
    {
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
                    foreach (ModObjectData t in supportedMods.SupportedModifiers) choices.Add(t.mName);

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
                                newValue = EditorGUILayout.Toggle(modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue.Trim() == "True").ToString();
                                modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue = newValue;
                                break;

                            case ((int)ModVar.Type.Int):
                                int tempint; System.Int32.TryParse(modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue.Trim(), out tempint);
                                newValue = EditorGUILayout.IntField(tempint).ToString().Trim();
                                modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue = newValue;
                                break;

                            case ((int)ModVar.Type.Float):
                                float tempfloat; float.TryParse(modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue.Trim(), out tempfloat);
                                newValue = EditorGUILayout.FloatField(tempfloat).ToString().Trim();
                                modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue = newValue;
                                break;

                            case ((int)ModVar.Type.List):
                                string tmplist = EditorGUILayout.TextField(modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue.Trim());
                                modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue = tmplist;
                                if (!ValidateJSON(tmplist))
                                    EditorGUILayout.HelpBox("Please follow json formatting for lists", MessageType.Warning);
                                break;

                            case ((int)ModVar.Type.UnityEvent):
                                SerializedProperty m_OnAction = modVars.GetArrayElementAtIndex(i).FindPropertyRelative("OnAction");
                                EditorGUILayout.PropertyField(m_OnAction);
                                break;

                            default:  // ,Float , STR
                                newValue = EditorGUILayout.TextField(modVars.GetArrayElementAtIndex(i).FindPropertyRelative("value").stringValue.Trim());
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


        public static bool ValidateJSON(string s)
        {
            try
            {
                JToken.Parse(s);
                return true;
            }
            catch (JsonReaderException ex)
            { 
                return false;
            }
        }
    }
}