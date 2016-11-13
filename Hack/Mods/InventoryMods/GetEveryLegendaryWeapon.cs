using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.InventoryMods
{
    class GetEveryLegendaryWeapon : Module
    {
        public GetEveryLegendaryWeapon() : base("Get Legendary Wpns", KeyCode.None, Categories.mInventory, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<GameParameters>.IsInstanceValid && !MonoSingleton<Vault>.IsInstanceValid) return;
            foreach (DwellerWeaponItem wep in MonoSingleton<GameParameters>.Instance.Items.WeaponsList)
            {
                if (wep.ItemRarity == EItemRarity.Legendary) {
                    DwellerItem item2 = new DwellerItem(EItemType.Weapon, wep.GetAsDwellerItem().Id);
                    MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
                }
            }
        }
    }
}
