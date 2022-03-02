using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

namespace outrealxr.holomod
{
    public class BehaviorTreeProvider : Provider
    {
        public Behavior tree;

        public override string ModKey => "behaviortree";

        public override string providerType => GetType().Name;

        public override void FromJObject(JObject data)
        {
            foreach (var variable in tree.GetAllVariables())
            {
                if(data.ContainsKey(variable.Name))
                {
                    switch(variable.GetType().Name)
                    {
                        case "SharedInt":
                            tree.SetVariableValue(variable.Name, data.GetValue(variable.Name).Value<int>());
                            break;
                        case "SharedFloat":
                            tree.SetVariableValue(variable.Name, data.GetValue(variable.Name).Value<float>());
                            break;
                        case "SharedDouble":
                            tree.SetVariableValue(variable.Name, data.GetValue(variable.Name).Value<double>());
                            break;
                        case "SharedString":
                            tree.SetVariableValue(variable.Name, data.GetValue(variable.Name).Value<string>());
                            break;
                        case "SharedBool":
                            tree.SetVariableValue(variable.Name, data.GetValue(variable.Name).Value<bool>());
                            break;
                        default:
                            Debug.LogWarning($"[BehaviorTreeProvider] Unknown type {variable.GetType().Name} of variable {variable.Name}");
                            break;
                    }
                    
                }
                else
                {
                    Debug.LogWarning($"[BehaviorTreeProvider] Missing variable {variable.Name}");
                }
            }
        }

        public override JObject ToJObject()
        {
            JObject data = new JObject();
            foreach (var variable in tree.GetAllVariables())
                if (IsVariableValid(variable))
                    data.Add(new JProperty(variable.Name, variable.GetValue()));
            return data;
        }

        bool IsVariableValid(SharedVariable variable)
        {
            return "SharedInt,SharedFloat,SharedDouble,SharedString,SharedBool".Contains(variable.GetType().Name);
        }

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }
    }
}