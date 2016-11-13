using FSHack.Hack.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FSHack.Hack.Mods.InventoryMods
{
    class GetEveryLegendaryOutfit : Module
    {
        public GetEveryLegendaryOutfit() : base("Get Legendary Outfits", KeyCode.None, Categories.mInventory, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<GameParameters>.IsInstanceValid && !MonoSingleton<Vault>.IsInstanceValid) return;
            foreach (DwellerOutfitItem wep in MonoSingleton<GameParameters>.Instance.Items.OutfitList)
            {
                if (wep.ItemRarity == EItemRarity.Legendary)
                {
                    DwellerItem item2 = new DwellerItem(EItemType.Outfit, wep.GetAsDwellerItem().Id);
                    MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
                }
            }
        }
    }
}
