using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.InventoryMods
{
    class GetAllWeapons : Module
    {
        public GetAllWeapons() : base("Give All Wpns", KeyCode.None, Categories.mInventory, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if(MonoSingleton<GameParameters>.IsInstanceValid && MonoSingleton<Vault>.IsInstanceValid)
            foreach (DwellerWeaponItem weapon in MonoSingleton<GameParameters>.Instance.Items.WeaponsList)
            {
                DwellerItem item2 = new DwellerItem(EItemType.Weapon, weapon.GetAsDwellerItem().Id);
                MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
            }
        }
    }
}
