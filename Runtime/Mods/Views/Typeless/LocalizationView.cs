using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.holomod
{
    public class LocalizationView : View
    {
        public enum Locale
        {
            English,
            Arabic
        }

        [SerializeField] private Locale _target;
        [SerializeField] private UnityEvent _onLocaleValid;
        [SerializeField] private UnityEvent _onLocaleInvalid;

        public void LanguageChanged (Locale locale) {
            if (_target == locale)
                _onLocaleValid?.Invoke();
            else
                _onLocaleInvalid?.Invoke();
        }

        public override string Tags => "localization";  
    }
}