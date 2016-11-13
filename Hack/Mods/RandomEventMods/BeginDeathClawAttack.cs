﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.RandomEventMods
{
    class BeginDeathClawAttack : Module
    {
        public BeginDeathClawAttack() : base("Start Death Claw Atk", KeyCode.None, Categories.mRandomEvents, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (MonoSingleton<Vault>.IsInstanceValid)
                MonoSingleton<Vault>.Instance.EmergencyState.DeathclawMgr.BeginAttack();
        }
    }
}