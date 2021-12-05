using MelonLoader;
using System;
using System.Collections;
using UIExpansionKit.API;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;

[assembly: MelonInfo(typeof(Invite__fix.Invite_fix), "Invite+ fix", "1.3.4", "MarkViews")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace Invite__fix {

    public class Invite_fix : MelonMod {

        public override void OnApplicationStart() {
            MelonCoroutines.Start(UiManagerInitializer());
        }

            public IEnumerator UiManagerInitializer() {
            while (VRCUiManager.prop_VRCUiManager_0 == null) yield return null;

            Button button = GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/OnlineFriendButtons/Invite").GetComponent<Button>();

            ExpansionKitApi.GetExpandedMenu(ExpandedMenu.UserDetailsMenu).AddSimpleButton("Invite to invite+", new Action(() => {
                if (RoomManager.field_Internal_Static_ApiWorldInstance_0?.type == InstanceAccessType.InvitePlus) {
                    button.onClick.Invoke();
                } else {
                    MelonLogger.Warning("UIX Invite button only works in Invite+ worlds");
                }
            }));

        }

    }

}
