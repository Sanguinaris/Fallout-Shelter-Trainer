using FSHack.Hack.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FSHack.Hack.Mods.InventoryMods
{
    class GetBestOutfit : Module
    {
        public GetBestOutfit() : base("Get Best Outfit", KeyCode.None, Categories.mInventory, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<GameParameters>.IsInstanceValid && !MonoSingleton<Vault>.IsInstanceValid) return;
            int bestAvgPrice = 0;
            DwellerOutfitItem weapon = new DwellerOutfitItem();
            foreach (DwellerOutfitItem wep in MonoSingleton<GameParameters>.Instance.Items.OutfitList)
            {
                if (wep.SellPrice > bestAvgPrice)
                {
                    weapon = wep;
                }
            }

            DwellerItem item2 = new DwellerItem(EItemType.Outfit, weapon.GetAsDwellerItem().Id);
            MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);

            foreach (DwellerOutfitItem wep in MonoSingleton<GameParameters>.Instance.Items.OutfitList)
            {
                if (wep.SellPrice > bestAvgPrice)
                {
                    weapon = wep;
                }
            }

            item2 = new DwellerItem(EItemType.Outfit, weapon.GetAsDwellerItem().Id);
            MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
        }
    }
}
