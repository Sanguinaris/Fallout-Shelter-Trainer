using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.VaultMods
{
    class UnlimitedDwellers : Module
    {
        public UnlimitedDwellers() : base("Unlimited Dwellers", KeyCode.None, Categories.mVault, GuiNames.Toggle)
        {
        }

        float maxDwellersVault = -1;

        public override void onEnable()
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            maxDwellersVault = MonoSingleton<Vault>.Instance.MaxDwellers;
            MonoSingleton<Vault>.Instance.MaxDwellers = 133337;
        }

        public override void onDisable()
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            if (maxDwellersVault < 0) return;
            MonoSingleton<Vault>.Instance.MaxDwellers = (int)maxDwellersVault;
        }
    }
}
