using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.RandomEventMods
{
    class RushAlwaysSucceeds : Module
    {
        public RushAlwaysSucceeds() : base("Rush Always Succeeds", KeyCode.None, Categories.mRandomEvents, GuiNames.Toggle)
        {
        }

        public static bool shouldAlwaysSuccedRush = false;

        public override void onEnable()
        {
            shouldAlwaysSuccedRush = true;
        }

        public override void onDisable()
        {
            shouldAlwaysSuccedRush = false;
        }
    }
}
