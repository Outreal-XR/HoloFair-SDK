using System;
using System.Collections.Generic;
using com.outrealxr.avatars.revised;
using UnityEngine;
using UnityEngine.Pool;

namespace com.outrealxr.avatars.ManyToMany
{
    public class AvatarSelectViewPool : MonoBehaviour
    {
        [SerializeField] private GameObject _viewPrefab;
        [SerializeField] private Transform _viewParent;

        private IObjectPool<AvatarSelectView> _pool;
        private readonly List<AvatarSelectView> _active = new ();

        private void Awake() {
            _pool = new ObjectPool<AvatarSelectView>(CreateView, GetView, ReleaseView);
        }
        
        private void Start() {
            AvatarCatalogueFetcher.FetchCatalogue();
            AvatarCatalogueFetcher.OnCatalogueReceived += CatalogueReceived;
        }

        private void CatalogueReceived(List<AvatarCatalogueSet.Data> catalogueData) {
            foreach (var data in catalogueData) {
                _pool.Get().UpdateView(data.Image, () => {
                    LocalAvatarOwner.Instance.SetSrc(data.AvatarAsset.RuntimeKey.ToString());
                });
            }
        }

        private void GetView(AvatarSelectView view) {
            view.gameObject.SetActive(true);
            _active.Add(view);
        }

        private AvatarSelectView CreateView() {
            var obj = Instantiate(_viewPrefab, _viewParent);
            return obj.GetComponent<AvatarSelectView>();
        }

        private void ReleaseView(AvatarSelectView view) {
            view.gameObject.SetActive(false);
            _active.Remove(view);
        }

        public void UpdateView(Sprite sprite, Action action) {
            var view = _pool.Get();
            view.UpdateView(sprite, action);
        }

        public void ResetViews() {
            foreach (var view in _active) _pool.Release(view);
        }
    }
}