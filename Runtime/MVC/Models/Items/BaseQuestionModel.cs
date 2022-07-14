using System;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public abstract class BaseQuestionModel : Model
    {
        public override string type => "question";
        
        [SerializeField] protected int id;
        [SerializeField] protected string question;
        [SerializeField] protected Option[] options;

        [SerializeField, Space(10)] protected UnityEvent OnAvailable;
        [SerializeField] protected UnityEvent OnUnavailable;
        [SerializeField, Space(5)] protected UnityEvent OnCorrectAnswer;
        [SerializeField] protected UnityEvent OnIncorrectAnswer;

        [HideInInspector] public string groupId;
        [HideInInspector] public string uuId;
        
        protected abstract void GetData ();
        protected abstract void AvailableText (string text);
        public abstract void SelectOption (int i, float timeTaken);
        
        [Serializable]
        protected struct Option {
            public int ID;
            public string OptionText;
        }
    }
}