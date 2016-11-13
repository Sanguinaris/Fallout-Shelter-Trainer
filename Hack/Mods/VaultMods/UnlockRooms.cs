using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.VaultMods
{
    class UnlockRooms : Module
    {
        public UnlockRooms() : base("Unlock Rooms", KeyCode.None, Categories.mVault, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<VaultGUIManager>.IsInstanceValid) return;
            foreach (ERoomType room in Enum.GetValues(typeof(ERoomType)))
                MonoSingleton<VaultGUIManager>.Instance.m_RoomsBuildWindow.Cheat_UnlockRoom(room);
        }
    }
}
