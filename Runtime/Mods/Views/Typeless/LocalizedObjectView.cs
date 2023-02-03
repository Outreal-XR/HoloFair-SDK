using UnityEngine;

namespace com.outrealxr.holomod
{
    public class LocalizedObjectView : View
    {
        public enum Locale
        {
            English,
            Arabic
        }

        [SerializeField] private Locale _target;
        [SerializeField] private GameObject _object;

        public void LanguageChanged (Locale locale) {
            _object.SetActive(locale == _target);
        }
    }
}