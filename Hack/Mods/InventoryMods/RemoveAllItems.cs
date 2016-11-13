using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.InventoryMods
{
    class RemoveAllItems : Module
    {
        public RemoveAllItems() : base("Remove All Items", KeyCode.None, Categories.mInventory, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if(MonoSingleton<Vault>.IsInstanceValid)
            {
                MonoSingleton<Vault>.Instance.Inventory.Clear();
            }
        }
    }
}
