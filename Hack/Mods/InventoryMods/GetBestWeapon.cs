using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.InventoryMods
{
    class GetBestWeapon : Module
    {
        public GetBestWeapon() : base("Get Best Wpn", KeyCode.None, Categories.mInventory, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<GameParameters>.IsInstanceValid && !MonoSingleton<Vault>.IsInstanceValid) return;
            float bestAvgDamage = 0;
            DwellerWeaponItem weapon = new DwellerWeaponItem();
            foreach (DwellerWeaponItem wep in MonoSingleton<GameParameters>.Instance.Items.WeaponsList)
            {
                if(wep.AverageDamage > bestAvgDamage)
                {
                    weapon = wep;
                    bestAvgDamage = wep.AverageDamage;
                }
            }

            DwellerItem item2 = new DwellerItem(EItemType.Weapon, weapon.GetAsDwellerItem().Id);
            MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
        }
    }
}
