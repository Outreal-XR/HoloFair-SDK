using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public static class InputDataModel
    {
    	public enum AuthMode
        {
            ThirdParty = 0,
            HoloFair = 1
        }

        public static string code = "7153208", uuid = "", avatar = "ybot basic", remoteWorldModelPath = "";
        public static int authMode = (int) AuthMode.ThirdParty;
        public static int userid = -1;
        public static string username = "", roomName = "";

        public static void LoadPlayerPrefs()
        {
            SetCode(PlayerPrefs.GetString(DeepLinkMap.code, code));
            SetUUID(PlayerPrefs.GetString(DeepLinkMap.uuid, uuid));
        }

        public static void SetRemoteWorldModelPath(string val)
        {
            remoteWorldModelPath = val;
            Debug.Log($"[InputDataModel] {DeepLinkMap.remoteWorldModelPath} is set to {remoteWorldModelPath}");
        }

        public static void SetCode(string code)
        {
            InputDataModel.code = code;
            Debug.Log($"[InputDataModel] {DeepLinkMap.code} is set to {InputDataModel.code}");
            PlayerPrefs.SetString(DeepLinkMap.code, InputDataModel.code);
        }

        public static void SetUUID(string uuid)
        {
            InputDataModel.uuid = uuid;
            UuidView.SetUuId(uuid);
            Debug.Log($"[InputDataModel] {DeepLinkMap.uuid} is set to {InputDataModel.uuid}");
            PlayerPrefs.SetString(DeepLinkMap.uuid, InputDataModel.uuid);
        }

        public static void SetAvatar(string avatar)
        {
            InputDataModel.avatar = avatar;
            Debug.Log($"[InputDataModel] {DeepLinkMap.avatar} is set to {InputDataModel.avatar}");
        }

        public static void SetAuthMode(string val)
        {
            if (!int.TryParse(val, out authMode)) Debug.Log($"[InputDataModel] Invalid value for auto mode: {val}. Expected a int from 0 ({AuthMode.ThirdParty}) to 1 ({AuthMode.HoloFair})");
        }

        public static void SetDebug(string val) {
            throw new NotImplementedException();
        }
        
        public static void SetRoomName(string room)
        {
            roomName = room;
        }

        public static AuthMode GetAuthMode()
        {
            return (AuthMode) authMode;
        }

        public static class DeepLinkMap
        {
            public const string code = "code";
            public const string uuid = "uuid";
            public const string remoteWorldModelPath = "remoteWorldModelPath";
            public const string avatar = "avatar";
            public const string authMode = "authMode";
            public const string debug = "debug";
        }
    }
}