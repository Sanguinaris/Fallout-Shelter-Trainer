using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.DwellerMods
{
    class SpawnDweller : Module
    {
        public SpawnDweller() : base("Spawn Dweller", KeyCode.None, Categories.mDweller, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if(MonoSingleton<DwellerSpawner>.IsInstanceValid)
            /*MonoSingleton<Vault>.Instance.RegisterDweller(*/MonoSingleton<DwellerSpawner>.Instance.CreateWaitingDweller(EGender.Any, false, 0, EDwellerRarity.Legendary)/*)*/;
        }
    }
}
