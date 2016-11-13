using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.VaultMods
{
    class UnlimitedStorageSpace : Module
    {
        public UnlimitedStorageSpace() : base("Infinite Storage Space", KeyCode.None, Categories.mInventory, GuiNames.Toggle)
        {
        }

        int defStorageLimit = 100;
        public override void onEnable()
        {
            if (MonoSingleton<Vault>.IsInstanceValid)
            {
                defStorageLimit = MonoSingleton<Vault>.Instance.Inventory.ItemCountMax;
                MonoSingleton<Vault>.Instance.Inventory.SetMaxItems(13333337);
            }
        }

        public override void onDisable()
        {
            if (MonoSingleton<Vault>.IsInstanceValid)
            {
                MonoSingleton<Vault>.Instance.Inventory.SetMaxItems(defStorageLimit);
            }
        }
    }
}
