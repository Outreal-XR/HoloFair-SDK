namespace com.outrealxr.avatars.revised
{
    public class LocalAvatarOwner : AvatarOwner
    {
        public static LocalAvatarOwner Instance { get; private set; }

        private void Awake() {
            Instance = this;
        }

        public bool IsAvatarDefault => Src.Equals("ybot basic");
    }
}