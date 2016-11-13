using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.DwellerMods
{
    class LevelAllUp : Module
    {
        public LevelAllUp() : base("Level UP All", KeyCode.None, Categories.mDweller, GuiNames.ButtonWSlider)
        {
            base.maxSliderValue = 50;
        }

        public override void onButtonPress()
        {
            if(MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach(Dweller inh in MonoSingleton<DwellerManager>.Instance.Dwellers)
                {
                    if (inh.IsRaider) continue;
                    for(int i = 0; i < base.sliderValue; i++)
                    {
                        inh.Experience.LevelUP();
                    }
                }
        }
    }
}
