using MelonLoader;
using System;
using System.Collections;
using UIExpansionKit.Components;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;

[assembly: MelonInfo(typeof(Invite__fix.Invite_fix), "Invite+ fix", "1.3.3", "MarkViews")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace Invite__fix {

    public class Invite_fix : MelonMod {

        GameObject socialMenu;
        Image background;

        public override void OnApplicationStart() {
            MelonCoroutines.Start(UiManagerInitializer());
        }

            public IEnumerator UiManagerInitializer() {
            while (VRCUiManager.prop_VRCUiManager_0 == null) yield return null;

            socialMenu = GameObject.Find("UserInterface/MenuContent/Screens/Social");
            background = GameObject.Find("UserInterface/MenuContent/Backdrop/Backdrop/Background").GetComponent<Image>();

            GameObject userInfo = GameObject.Find("UserInterface/MenuContent/Screens/UserInfo");
            Button button = GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/OnlineFriendButtons/Invite").GetComponent<Button>();

            userInfo.AddComponent<EnableDisableListener>().OnEnabled += () => {
                MelonCoroutines.Start(delayRun(() => {
                    if (RoomManager.field_Internal_Static_ApiWorldInstance_0?.type == InstanceAccessType.InvitePlus) {
                        button.interactable = true;
                        button.m_Interactable = true;
                    }
                }));
            };
        }

        public IEnumerator delayRun(Action action) {
            yield return new WaitForSeconds(0.1f);

            if (socialMenu.active)
            while (socialMenu.active == true)
                yield return null;

            if (background.color.a < 0.9)
                while (background.color.a < 0.9)
                    yield return null;

            action.Invoke();
        }

    }

}
