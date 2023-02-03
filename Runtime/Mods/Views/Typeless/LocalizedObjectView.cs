using UnityEngine;

namespace com.outrealxr.holomod
{
    public class LocalizedObjectView : View
    {
        [SerializeField] private GameObject _englishObject;
        [SerializeField] private GameObject _arabicObject;
        
        public enum Locale {
            English,
            Arabic
        }

        public void LanguageChanged (Locale locale) {
            _englishObject.SetActive(locale == Locale.English);
            _arabicObject.SetActive(locale == Locale.Arabic);
        }
    }
}