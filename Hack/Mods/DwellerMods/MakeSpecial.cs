using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.DwellerMods
{
    class MakeSpecial : Module
    {
        public MakeSpecial() : base("Make evry1 Special", KeyCode.None, Categories.mDweller, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach(Dweller inh in MonoSingleton<DwellerManager>.Instance.Dwellers)
                {
                    if (inh.IsRaider) continue;
                    inh.Stats.GetStat(ESpecialStat.Agility).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Charisma).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Endurance).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Intelligence).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Luck).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Perception).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Strength).IncreaseBaseValue(100);
                }
        }
    }
}
