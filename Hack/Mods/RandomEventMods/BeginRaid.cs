using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.RandomEventMods
{
    class BeginRaid : Module
    {
        public BeginRaid() : base("Start Raid", KeyCode.None, Categories.mRandomEvents, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            MonoSingleton<Vault>.Instance.EmergencyState.RaiderMgr.BeginAttack();
        }
    }
}
