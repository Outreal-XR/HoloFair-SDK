using System;
using System.Collections.Generic;
using com.outrealxr.holomod;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace com.outrealxr.avatars.ManyToMany
{
    public static class AvatarCatalogueFetcher
    {
        private const string UrlFormat = "{0}{1}";

        private static List<AvatarCatalogueSet.Data> _datas = new();

        public static void FetchCatalogue() {
            _datas.Clear();

            var formattedUrl = string.Format(UrlFormat, InputDataModel.code, PlatformId);
            var www = UnityWebRequest.Get(formattedUrl);
            www.downloadHandler = new DownloadHandlerBuffer();

            var handler = www.SendWebRequest();
            handler.completed += _ => CatalogueFetched(www);
        }

        private static async void CatalogueFetched(UnityWebRequest www) {
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.LogError($"[AvatarSelectFactory] Error: {www.error}");
                return;
            }

            var array = JArray.Parse(www.downloadHandler.text);

            foreach (var jToken in array) {
                var catalogue = jToken.Value<string>();
                await Addressables.LoadContentCatalogAsync(catalogue, true).Task;
            }

            var loadResourceLocationsHandle =
                Addressables.LoadResourceLocationsAsync("AvatarSelectData", typeof(AvatarCatalogueSet));
            await loadResourceLocationsHandle.Task;

            if (loadResourceLocationsHandle.Status != AsyncOperationStatus.Succeeded) {
                //TODO Throw warning here
                return;
            }

            foreach (var location in loadResourceLocationsHandle.Result) {
                var loadAssetHandle = Addressables.LoadAssetAsync<AvatarCatalogueSet>(location);
                await loadAssetHandle.Task;
                var model = loadAssetHandle.Result;

                foreach (var data in model.CatalogueSetData) {

                }
            }
        }

        private static int PlatformId {
            get {
                return Application.platform switch {
                    RuntimePlatform.WebGLPlayer => 1,
                    RuntimePlatform.WindowsPlayer => 2,
                    RuntimePlatform.WindowsEditor => 2,
                    RuntimePlatform.OSXPlayer => 3,
                    RuntimePlatform.OSXEditor => 3,
                    RuntimePlatform.IPhonePlayer => 4,
                    RuntimePlatform.Android => 5,
                    _ => 0
                };
            }
        }

    }
}