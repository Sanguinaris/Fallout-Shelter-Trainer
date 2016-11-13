using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.VaultMods
{
    class InfiniteNuka : Module
    {
        public InfiniteNuka() : base("Infinite Nuka", KeyCode.None, Categories.mVault, GuiNames.Toggle)
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
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            MonoSingleton<Vault>.Instance.Storage.AddResource(new GameResources(EResource.Nuka, 1337));
        }
    }
}
