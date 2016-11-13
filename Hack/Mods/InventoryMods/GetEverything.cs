using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.InventoryMods
{
    class GetEverything : Module
    {
        public GetEverything() : base("Get Everything", KeyCode.None, Categories.mInventory, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<GameParameters>.IsInstanceValid && !MonoSingleton<Vault>.IsInstanceValid) return;
            foreach (DwellerWeaponItem wep in MonoSingleton<GameParameters>.Instance.Items.WeaponsList)
            {
                DwellerItem item2 = new DwellerItem(EItemType.Weapon, wep.GetAsDwellerItem().Id);
                MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
            }
            foreach (DwellerOutfitItem wep in MonoSingleton<GameParameters>.Instance.Items.OutfitList)
            {
                DwellerItem item2 = new DwellerItem(EItemType.Outfit, wep.GetAsDwellerItem().Id);
                MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
            }
            foreach(DwellerJunkItem junk in MonoSingleton<GameParameters>.Instance.Items.JunksList)
            {
                DwellerItem item2 = new DwellerItem(EItemType.Junk, junk.GetAsDwellerItem().Id);
                MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
            }

        }
    }
}
