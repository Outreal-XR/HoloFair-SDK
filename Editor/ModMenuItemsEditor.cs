using UnityEditor;
using UnityEngine;

namespace outrealxr.holomod.Editor
{
    public class ModMenuItemsEditor : MonoBehaviour
    {
        [MenuItem("GameObject/HoloModSDK/Video Mod Object")]
        private static void CreateVideoModObject(MenuCommand menuCommand) {
            var videoMod = new GameObject("Video Mod");

            videoMod.AddComponent<VideoProvider>();

            GameObjectUtility.SetParentAndAlign(videoMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(videoMod, "Create " + videoMod.name);
            Selection.activeObject = videoMod;
        }
        
        [MenuItem("GameObject/HoloModSDK/Image Mod Object")]
        private static void CreateImageModObject(MenuCommand menuCommand) {
            var imageMod = new GameObject("Image Mod");

            imageMod.AddComponent<ImageProvider>();

            GameObjectUtility.SetParentAndAlign(imageMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(imageMod, "Create " + imageMod.name);
            Selection.activeObject = imageMod;
        }
        
        [MenuItem("GameObject/HoloModSDK/Privilege Mod Object")]
        private static void CreatePrivilegeModObject(MenuCommand menuCommand) {
            var privilegeMod = new GameObject("Privilege Mod");

            privilegeMod.AddComponent<PrivilageProvider>();

            GameObjectUtility.SetParentAndAlign(privilegeMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(privilegeMod, "Create " + privilegeMod.name);
            Selection.activeObject = privilegeMod;
        }
        
        [MenuItem("GameObject/HoloModSDK/Respawn Mod Object")]
        private static void CreateRespawnModObject(MenuCommand menuCommand) {
            var respawnMod = new GameObject("default");

            var respawnProvider = respawnMod.AddComponent<RespawnProvider>();
            respawnProvider.radius = 1f;

            respawnMod.AddComponent<OnStartHandler>().view = respawnMod.GetComponent<View>();
            
            GameObjectUtility.SetParentAndAlign(respawnMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(respawnMod, "Create " + respawnMod.name);
            Selection.activeObject = respawnMod;
        }
        
        [MenuItem("GameObject/HoloModSDK/Link Mod Object")]
        private static void CreateLinkModObject(MenuCommand menuCommand) {
            var linkMod = new GameObject("Link Mod");

            linkMod.AddComponent<LinkProvider>();

            GameObjectUtility.SetParentAndAlign(linkMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(linkMod, "Create " + linkMod.name);
            Selection.activeObject = linkMod;
        }

        [MenuItem("GameObject/HoloModSDK/Room Settings")]
        private static void CreateRoomSettings(MenuCommand menuCommand) {
            var roomSettingsObject = new GameObject("Room Settings");

            var provider = roomSettingsObject.AddComponent<RoomSettingsProvider>();

            var lower = new GameObject("Lower Bounds").transform;
            var higher = new GameObject("Higher Bounds").transform;
            lower.SetParent(roomSettingsObject.transform);
            higher.SetParent(roomSettingsObject.transform);
            provider.lowerBound = lower;
            provider.higherBound = higher;
            
            GameObjectUtility.SetParentAndAlign(roomSettingsObject, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(roomSettingsObject, "Create " + roomSettingsObject.name);
            Selection.activeObject = roomSettingsObject;
        }

        [MenuItem("GameObject/HoloModSDK/PlayableDirector Mod Object")]
        private static void CreatePlayableDirectorModObject(MenuCommand menuCommand) {
            var playableDirectorMod = new GameObject("PlayableDirector Mod");

            playableDirectorMod.AddComponent<PlayableDirectorProvider>();

            GameObjectUtility.SetParentAndAlign(playableDirectorMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(playableDirectorMod, "Create " + playableDirectorMod.name);
            Selection.activeObject = playableDirectorMod;
        }
        
        [MenuItem("GameObject/HoloModSDK/Portal Mod Object")]
        private static void CreatePortalModObject(MenuCommand menuCommand) {
            var portal = new GameObject("Portal");

            portal.AddComponent<PortalProvider>();

            GameObjectUtility.SetParentAndAlign(portal, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(portal, "Create " + portal.name);
            Selection.activeObject = portal;
        }
        
        [MenuItem("GameObject/HoloModSDK/Zone Talk Mod Object")]
        private static void CreateZoneTalkModObject(MenuCommand menuCommand) {
            var zoneTalk = new GameObject("Zone Talk");

            zoneTalk.AddComponent<ZoneTalkProvider>();

            GameObjectUtility.SetParentAndAlign(zoneTalk, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(zoneTalk, "Create " + zoneTalk.name);
            Selection.activeObject = zoneTalk;
        }
        
        [MenuItem("GameObject/HoloModSDK/Game Queuer Mod Object")]
        private static void CreateGameQueuerModObject(MenuCommand menuCommand) {
            var gameQueuer = new GameObject("Game Queue");

            gameQueuer.AddComponent<GameQueuerProvider>();

            GameObjectUtility.SetParentAndAlign(gameQueuer, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(gameQueuer, "Create " + gameQueuer.name);
            Selection.activeObject = gameQueuer;
        }

        [MenuItem("GameObject/HoloModSDK/Animation Mod Object")]
        private static void CreateAnimationModObject(MenuCommand menuCommand) {
            var animationMod = new GameObject("Animation Mod Object");

            var mod = animationMod.AddComponent<AnimationProvider>();

            var pivot = new GameObject("Avatar Pivot");
            var respawn = new GameObject("Respawn");
            pivot.transform.SetParent(animationMod.transform);
            respawn.transform.SetParent(animationMod.transform);

            mod.avatarPivot = pivot.transform;
            mod.respawnPoint = respawn.transform;
            
            GameObjectUtility.SetParentAndAlign(animationMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(animationMod, "Create " + animationMod.name);
            Selection.activeObject = animationMod;
        }
        
        [MenuItem("GameObject/HoloModSDK/Animator Mod Object")]
        private static void CreateAnimatorModObject(MenuCommand menuCommand) {
            var animatorMod = new GameObject("Animator Mod Object");

            animatorMod.AddComponent<AnimatorProvider>();

            GameObjectUtility.SetParentAndAlign(animatorMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(animatorMod, "Create " + animatorMod.name);
            Selection.activeObject = animatorMod;
        }
        
        [MenuItem("GameObject/HoloModSDK/BehaviorTree Mod Object")]
        private static void CreateBehaviorTreeModObject(MenuCommand menuCommand) {
            var behaviorTreeMod = new GameObject("BehaviorTree Mod Object");

            behaviorTreeMod.AddComponent<BehaviorTreeProvider>();

            GameObjectUtility.SetParentAndAlign(behaviorTreeMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(behaviorTreeMod, "Create " + behaviorTreeMod.name);
            Selection.activeObject = behaviorTreeMod;
        }


        [MenuItem("CONTEXT/Provider/Add Box Trigger Handler")]
        private static void AddBoxTriggerToModObject(MenuCommand menuCommand) {
            //Trigger Collider
            var colliderChild = new GameObject("Trigger");
            colliderChild.transform.SetParent((menuCommand.context as Provider).transform);

            var collider = colliderChild.AddComponent<BoxCollider>();
            collider.isTrigger = true; 
            var handler = colliderChild.AddComponent<OnTriggerHandler>();
            handler.TargetTag = "LocalPlayer";
            
            Undo.RegisterCreatedObjectUndo(colliderChild, "Create " + colliderChild.name);
            Selection.activeObject = colliderChild;
        }
        
        [MenuItem("CONTEXT/Provider/Add Sphere Trigger Handler")]
        private static void AddSphereTriggerToModObject(MenuCommand menuCommand) {
            //Trigger Collider
            var colliderChild = new GameObject("Trigger");
            colliderChild.transform.SetParent((menuCommand.context as Provider).transform);

            var collider = colliderChild.AddComponent<SphereCollider>();
            collider.isTrigger = true; 
            var handler = colliderChild.AddComponent<OnTriggerHandler>();
            handler.TargetTag = "LocalPlayer";
            
            Undo.RegisterCreatedObjectUndo(colliderChild, "Create " + colliderChild.name);
            Selection.activeObject = colliderChild;
        }
        
        [MenuItem("CONTEXT/Provider/Add Click Handler")]
        private static void AddClickToModObject(MenuCommand menuCommand) {
            //Trigger Collider
            var colliderChild = new GameObject("Click Trigger");
            colliderChild.transform.SetParent((menuCommand.context as Provider).transform);

            var collider = colliderChild.AddComponent<BoxCollider>();
            collider.isTrigger = true; 
            colliderChild.AddComponent<OnClickHandler>();

            Undo.RegisterCreatedObjectUndo(colliderChild, "Create " + colliderChild.name);
            Selection.activeObject = colliderChild;
        }
        
        [MenuItem("CONTEXT/Provider/Add Start Handler")]
        private static void AddStartToModObject(MenuCommand menuCommand) {
            (menuCommand.context as MonoBehaviour).gameObject.AddComponent<OnStartHandler>();
        }

    }
}
