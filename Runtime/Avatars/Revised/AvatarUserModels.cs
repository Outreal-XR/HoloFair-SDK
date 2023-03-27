using System.Collections.Generic;
using System.Linq;

namespace com.outrealxr.avatars.revised
{
    public static class AvatarUserModels
    {
        private static readonly Dictionary<int, AvatarModel> AvatarModels = new ();

        public static void UpdateAvatarModel(int id, AvatarUser user, string src) {
            if (!AvatarModels.ContainsKey(id) || AvatarModels[id] == null) {
                var userModel = AvatarModels.Values.FirstOrDefault(model => model.CompareUser(user));

                if (userModel != null) userModel = new AvatarModel(src, user);
                
                AvatarModels.Add(id, userModel);
            }
            AvatarModels[id].SetSource(src);
        }
    }
}