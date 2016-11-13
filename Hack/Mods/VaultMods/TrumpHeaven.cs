using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.VaultMods
{
    class TrumpHeaven : Module
    {
        public TrumpHeaven() : base("Trump's Heaven", KeyCode.Keypad1, Categories.mVault, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            foreach (Dweller inh in MonoSingleton<Vault>.Instance.Dwellers)
            {
                inh.SkinColor2 = Color.white;
            }
        }
    }
}
