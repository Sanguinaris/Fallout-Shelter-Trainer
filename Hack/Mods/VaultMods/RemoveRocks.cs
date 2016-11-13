using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.VaultMods
{
    class RemoveRocks : Module
    {
        public RemoveRocks() : base("Remove Rocks", KeyCode.None, Categories.mVault, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            foreach (RockZone rock in MonoSingleton<Vault>.Instance.ConstructionGrid.RockZones)
            {
                rock.DestroyRock(true);
            }
        }
    }
}
