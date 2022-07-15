using System;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public abstract class BasicQuestionModel : Model
    {
        public override string type => "question";
        
        [SerializeField] protected int id;
        public string question;
        public Option[] options;

        [SerializeField, Space(10)] protected UnityEvent OnAvailable;
        [SerializeField] protected UnityEvent OnUnavailable;
        [SerializeField, Space(5)] protected UnityEvent OnCorrectAnswer;
        [SerializeField] protected UnityEvent OnIncorrectAnswer;

        [HideInInspector] public int groupId;
        [HideInInspector] public string uuId;
        
        public abstract void GetData ();
        protected abstract void AvailableText (string text);
        public abstract void SelectOption (int i, float timeTaken);
        
        [Serializable]
        public struct Option {
            public int ID;
            public string OptionText;
        }
    }
}