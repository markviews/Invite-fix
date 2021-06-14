using MelonLoader;
using System;
using System.Collections;
using UIExpansionKit.Components;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;

[assembly: MelonInfo(typeof(Invite__fix.Invite_fix), "Invite+ fix", "1.2", "MarkViews")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace Invite__fix {

    public class Invite_fix : MelonMod {

        GameObject socialMenu;

        public override void OnApplicationStart() {
            MelonCoroutines.Start(UiManagerInitializer());
        }

            public IEnumerator UiManagerInitializer() {
            while (VRCUiManager.prop_VRCUiManager_0 == null) yield return null;
            socialMenu = GameObject.Find("UserInterface/MenuContent/Screens/Social");
            GameObject userInfo = GameObject.Find("UserInterface/MenuContent/Screens/UserInfo");
            Button button = GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/OnlineFriendButtons/Invite").GetComponent<Button>();

            userInfo.AddComponent<EnableDisableListener>().OnEnabled += () => {
                MelonCoroutines.Start(delayRun(() => {
                    if (RoomManager.field_Internal_Static_ApiWorldInstance_0?.InstanceType == ApiWorldInstance.AccessType.InvitePlus) {
                        button.interactable = true;
                        button.m_Interactable = true;
                    }
                }));
            };
        }

        public IEnumerator delayRun(Action action) {
            while (socialMenu.active == true)
                yield return null;
            action.Invoke();
        }

    }

}
