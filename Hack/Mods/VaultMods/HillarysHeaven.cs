using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.VaultMods
{
    class HillarysHeaven : Module
    {
        public HillarysHeaven() : base("Hillary's Heaven", KeyCode.Keypad1, Categories.mVault, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            foreach (Dweller inh in MonoSingleton<Vault>.Instance.Dwellers)
            {
                inh.SkinColor2 = Color.black;
            }
        }
    }
}
