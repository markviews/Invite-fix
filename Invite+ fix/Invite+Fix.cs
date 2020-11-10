using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;

namespace Invite__fix {
    public class Invite_fix : MelonMod {

        GameObject menu;

        public override void OnLevelWasInitialized(int level) {
            menu = GameObject.Find("/UserInterface/MenuContent/Screens/UserInfo/User Panel/OnlineFriend");
        }

        public override void OnGUI() {
            if (menu == null) return;
            if (!menu.active) return;
                if (RoomManager.field_Internal_Static_ApiWorldInstance_0?.InstanceType == ApiWorldInstance.AccessType.InvitePlus) {
                    Button button = GameObject.Find("/UserInterface/MenuContent/Screens/UserInfo/User Panel/OnlineFriend/Actions/Invite").GetComponent<Button>();
                    if (button.interactable) return;
                        button.interactable = true;
                        button.m_Interactable = true;
                }
        }

    }
}
