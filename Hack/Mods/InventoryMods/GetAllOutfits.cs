using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.InventoryMods
{
    class GetAllOutfits : Module
    {
        public GetAllOutfits() : base("Give All Outfits", KeyCode.None, Categories.mInventory, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {

            if (MonoSingleton<GameParameters>.IsInstanceValid && MonoSingleton<Vault>.IsInstanceValid)
                foreach (DwellerOutfitItem outfit in MonoSingleton<GameParameters>.Instance.Items.OutfitList)
                {
                    DwellerItem item2 = new DwellerItem(EItemType.Outfit, outfit.GetAsDwellerItem().Id);
                    MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
                }
        }
    }
}
