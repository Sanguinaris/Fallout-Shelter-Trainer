using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.DwellerMods
{
    class MassPregnancy : Module
    {
        public MassPregnancy() : base("Mass Pregnancy", KeyCode.None, Categories.mDweller, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if(MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach(Dweller inh in MonoSingleton<DwellerManager>.Instance.Dwellers)
                {
                    inh.SetPregnant(true);
                }
        }
    }
}
