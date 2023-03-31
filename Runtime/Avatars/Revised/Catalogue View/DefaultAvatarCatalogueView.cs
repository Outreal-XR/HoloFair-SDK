using com.outrealxr.avatars.ManyToMany;

namespace com.outrealxr.avatars.revised
{
    public class DefaultAvatarCatalogueView : AvatarCatalogueView
    {
        private void Awake() {
            DefaultView = this;
            AvatarCatalogueFetcher.FetchCatalogue();
        }
    }
}

