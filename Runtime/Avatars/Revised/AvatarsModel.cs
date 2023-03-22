using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public class AvatarsModel : MonoBehaviour
    {
        private readonly Dictionary<int, AvatarModel> _avatars = new ();

        public void UpdateAvatarModel(int id, AvatarView view, string src) {
            if (!_avatars.ContainsKey(id)) {
                var model = view.Model ?? new AvatarModel(src, view);
                _avatars.Add(id, model);
                view.SetModel(_avatars[id]);
            }
            _avatars[id].SetSource(src);
        }
    }
}