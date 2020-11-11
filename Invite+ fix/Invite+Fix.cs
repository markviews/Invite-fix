using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;

namespace Invite__fix {
    public class Invite_fix : MelonMod {

        GameObject menu;
        Button button;

        public override void VRChat_OnUiManagerInit() {
            menu = GameObject.Find("/UserInterface/MenuContent/Screens/UserInfo/User Panel/OnlineFriend");
            button = GameObject.Find("/UserInterface/MenuContent/Screens/UserInfo/User Panel/OnlineFriend/Actions/Invite").GetComponent<Button>();
        }

        public override void OnGUI() {
            if (menu == null) return;
            if (!menu.active) return;
                if (RoomManager.field_Internal_Static_ApiWorldInstance_0?.InstanceType == ApiWorldInstance.AccessType.InvitePlus) {
                    if (button.interactable) return;
                        button.interactable = true;
                        button.m_Interactable = true;
            }
        }
    }
}
