using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.DwellerMods
{
    class GodMode : Module
    {
        public GodMode() : base("God Mode", KeyCode.None, Categories.mDweller, GuiNames.Toggle)
        {
        }

        public override void onEnable()
        {
            EventMgr.Instance.registerEventListener(EventNames.onUpdate, this);
        }

        public override void onDisable()
        {
            EventMgr.Instance.deleteEventListener(EventNames.onUpdate, this);
        }

        public override void onUpdate()
        {
            if(MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach(Dweller inhabitant in MonoSingleton<DwellerManager>.Instance.Dwellers)
                {
                    if(!inhabitant.IsRaider)
                        inhabitant.Health.ChangeHealth(inhabitant.Health.HealthMax);
                }
        }
    }
}
