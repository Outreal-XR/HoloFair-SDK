using UnityEditor;
using UnityEngine;

namespace outrealxr.holomod.Editor
{
    public class ModMenuItemsEditor : MonoBehaviour
    {
        private const string BasePath = "GameObject/HoloMod/";
        
        [MenuItem(BasePath + "Video", false, 12)]
        private static void CreateVideoModObject(MenuCommand menuCommand) {
            var videoMod = new GameObject("Video Mod");

            videoMod.AddComponent<VideoModel>();

            GameObjectUtility.SetParentAndAlign(videoMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(videoMod, "Create " + videoMod.name);
            Selection.activeObject = videoMod;
        }
        
        [MenuItem(BasePath + "Image", false, 12)]
        private static void CreateImageModObject(MenuCommand menuCommand) {
            var imageMod = new GameObject("Image Mod");

            imageMod.AddComponent<ImageModel>();

            GameObjectUtility.SetParentAndAlign(imageMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(imageMod, "Create " + imageMod.name);
            Selection.activeObject = imageMod;
        }
        
        [MenuItem(BasePath + "Privilege", false, 12)]
        private static void CreatePrivilegeModObject(MenuCommand menuCommand) {
            var privilegeMod = new GameObject("Privilege Mod");

            privilegeMod.AddComponent<PrivilageModel>();

            GameObjectUtility.SetParentAndAlign(privilegeMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(privilegeMod, "Create " + privilegeMod.name);
            Selection.activeObject = privilegeMod;
        }
        
        [MenuItem(BasePath + "Respawn", false, 12)]
        private static void CreateRespawnModObject(MenuCommand menuCommand) {
            var respawnMod = new GameObject("default");

            var respawnProvider = respawnMod.AddComponent<RespawnModel>();
            respawnProvider.radius = 1f;

            GameObjectUtility.SetParentAndAlign(respawnMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(respawnMod, "Create " + respawnMod.name);
            Selection.activeObject = respawnMod;
        }
        
        [MenuItem(BasePath + "Link", false, 12)]
        private static void CreateLinkModObject(MenuCommand menuCommand) {
            var linkMod = new GameObject("Link Mod");

            linkMod.AddComponent<LinkModel>();

            GameObjectUtility.SetParentAndAlign(linkMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(linkMod, "Create " + linkMod.name);
            Selection.activeObject = linkMod;
        }

        [MenuItem(BasePath + "Room Settings", false, 12)]
        private static void CreateRoomSettings(MenuCommand menuCommand) {
            var roomSettingsObject = new GameObject("Room Settings");

            var provider = roomSettingsObject.AddComponent<RoomSettingsModel>();

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

        [MenuItem(BasePath + "PlayableDirector", false, 12)]
        private static void CreatePlayableDirectorModObject(MenuCommand menuCommand) {
            var playableDirectorMod = new GameObject("PlayableDirector Mod");

            playableDirectorMod.AddComponent<PlayableDirectorModel>();

            GameObjectUtility.SetParentAndAlign(playableDirectorMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(playableDirectorMod, "Create " + playableDirectorMod.name);
            Selection.activeObject = playableDirectorMod;
        }
        
        [MenuItem(BasePath + "Portal", false, 12)]
        private static void CreatePortalModObject(MenuCommand menuCommand) {
            var portal = new GameObject("Portal");

            portal.AddComponent<PortalModel>();

            GameObjectUtility.SetParentAndAlign(portal, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(portal, "Create " + portal.name);
            Selection.activeObject = portal;
        }
        
        [MenuItem(BasePath + "Focus Point", false, 12)]
        private static void CreateFocusPointModObject(MenuCommand menuCommand) {
            var focusPointMod = new GameObject("FocusPointMod");

            var mod = focusPointMod.AddComponent<FocusPointModel>();

            GameObjectUtility.SetParentAndAlign(focusPointMod, menuCommand.context as GameObject);
            
            var point = new GameObject("Focus Point").transform;
            point.SetParent(focusPointMod.transform);
            point.transform.localPosition = Vector3.zero;

            var focusPoint = point.gameObject.AddComponent<FocusPoint>();

            mod.focusPoint = focusPoint;
            
            Undo.RegisterCreatedObjectUndo(focusPointMod, "Create " + focusPointMod.name);
            Selection.activeObject = focusPointMod;
        }
        
        [MenuItem(BasePath + "Zone Talk", false, 12)]
        private static void CreateZoneTalkModObject(MenuCommand menuCommand) {
            var zoneTalk = new GameObject("Zone Talk");

            zoneTalk.AddComponent<ZoneTalkModel>();

            GameObjectUtility.SetParentAndAlign(zoneTalk, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(zoneTalk, "Create " + zoneTalk.name);
            Selection.activeObject = zoneTalk;
        }
        
        [MenuItem(BasePath + "Game Queue", false, 12)]
        private static void CreateGameQueuerModObject(MenuCommand menuCommand) {
            var gameQueuer = new GameObject("Game Queue");

            gameQueuer.AddComponent<GameQueuerModel>();

            GameObjectUtility.SetParentAndAlign(gameQueuer, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(gameQueuer, "Create " + gameQueuer.name);
            Selection.activeObject = gameQueuer;
        }

        [MenuItem(BasePath + "Animation", false, 12)]
        private static void CreateAnimationModObject(MenuCommand menuCommand) {
            var animationMod = new GameObject("Animation Mod Object");

            var mod = animationMod.AddComponent<AnimationModel>();

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
        
        [MenuItem(BasePath + "Animator", false, 12)]
        private static void CreateAnimatorModObject(MenuCommand menuCommand) {
            var animatorMod = new GameObject("Animator Mod Object");

            animatorMod.AddComponent<AnimatorModel>();

            GameObjectUtility.SetParentAndAlign(animatorMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(animatorMod, "Create " + animatorMod.name);
            Selection.activeObject = animatorMod;
        }
        
        [MenuItem(BasePath + "Force", false, 12)]
        private static void CreateForceModObject(MenuCommand menuCommand) {
            var forceMod = new GameObject("Force Mod Object");

            forceMod.AddComponent<RigidbodyForceModel>();

            GameObjectUtility.SetParentAndAlign(forceMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(forceMod, "Create " + forceMod.name);
            Selection.activeObject = forceMod;
        }
        
        [MenuItem(BasePath + "BehaviorTree", false, 12)]
        private static void CreateBehaviorTreeModObject(MenuCommand menuCommand) {
            var behaviorTreeMod = new GameObject("BehaviorTree Mod Object");

            //behaviorTreeMod.AddComponent<BehaviorTreeProvider>();

            GameObjectUtility.SetParentAndAlign(behaviorTreeMod, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(behaviorTreeMod, "Create " + behaviorTreeMod.name);
            Selection.activeObject = behaviorTreeMod;
        }


        [MenuItem("CONTEXT/Provider/Add Box Trigger Handler")]
        private static void AddBoxTriggerToModObject(MenuCommand menuCommand) {
            //Trigger Collider
            var colliderChild = new GameObject("Trigger");
            colliderChild.transform.SetParent((menuCommand.context as Model).transform);

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
            colliderChild.transform.SetParent((menuCommand.context as Model).transform);

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
            colliderChild.transform.SetParent((menuCommand.context as Model).transform);

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
