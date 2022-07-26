using TMPro;
using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicLockView : BasicStringView
    {
        [SerializeField] private TextMeshProUGUI input;

        public override void Apply() {
            (model as LockModel).AttemptPassword(input.text);
            input.text = "";
        }
    }
}