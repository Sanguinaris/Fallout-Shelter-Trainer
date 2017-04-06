using PPFalloutShellterTrn.Hack.MenuStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPFalloutShellterTrn.Hack.Modules
{
    class InventoryMods
    {
        static int OldMaxStorage = 0;
        public static void UnlimitedStorageEnable(Menu m)
        {
            if (MonoSingleton<Vault>.IsInstanceValid)
                OldMaxStorage = MonoSingleton<Vault>.Instance.Inventory.ItemCountMax;
        }
        public static void UnlimitedStorageDisable(Menu m)
        {
            if (MonoSingleton<Vault>.IsInstanceValid)
                MonoSingleton<Vault>.Instance.Inventory.SetMaxItems(OldMaxStorage);
        }
        public static void UnlimitedStorage(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            if(OldMaxStorage == 0)
                OldMaxStorage = MonoSingleton<Vault>.Instance.Inventory.ItemCountMax;
            MonoSingleton<Vault>.Instance.Inventory.SetMaxItems(1337);
        }

        public static void GetAll(Menu m)
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
            foreach (DwellerJunkItem junk in MonoSingleton<GameParameters>.Instance.Items.JunksList)
            {
                DwellerItem item2 = new DwellerItem(EItemType.Junk, junk.GetAsDwellerItem().Id);
                MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
            }
        }

        public static void GetAllWeapons(Menu m)
        {
            if (MonoSingleton<GameParameters>.IsInstanceValid && MonoSingleton<Vault>.IsInstanceValid)
                foreach (DwellerWeaponItem weapon in MonoSingleton<GameParameters>.Instance.Items.WeaponsList)
                {
                    DwellerItem item2 = new DwellerItem(EItemType.Weapon, weapon.GetAsDwellerItem().Id);
                    MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
                }
        }

        public static void GetAllOutfits(Menu m)
        {
            if (MonoSingleton<GameParameters>.IsInstanceValid && MonoSingleton<Vault>.IsInstanceValid)
                foreach (DwellerOutfitItem outfit in MonoSingleton<GameParameters>.Instance.Items.OutfitList)
                {
                    DwellerItem item2 = new DwellerItem(EItemType.Outfit, outfit.GetAsDwellerItem().Id);
                    MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
                }
        }

        public  static void GetAllJunk(Menu m)
        {
            if (MonoSingleton<GameParameters>.IsInstanceValid && MonoSingleton<Vault>.IsInstanceValid)
                foreach (DwellerOutfitItem outfit in MonoSingleton<GameParameters>.Instance.Items.OutfitList)
                {
                    DwellerItem item2 = new DwellerItem(EItemType.Junk, outfit.GetAsDwellerItem().Id);
                    MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
                }
        }

        public static void RemoveAll(Menu m)
        {
            if (MonoSingleton<Vault>.IsInstanceValid)
                MonoSingleton<Vault>.Instance.Inventory.Clear();
        }

        public static void GetBestWeapon(Menu m)
        {
            if (!MonoSingleton<GameParameters>.IsInstanceValid && !MonoSingleton<Vault>.IsInstanceValid) return;
            float bestAvgDamage = 0;
            DwellerWeaponItem weapon = new DwellerWeaponItem();
            foreach (DwellerWeaponItem wep in MonoSingleton<GameParameters>.Instance.Items.WeaponsList)
            {
                if (wep.AverageDamage > bestAvgDamage)
                {
                    weapon = wep;
                    bestAvgDamage = wep.AverageDamage;
                }
            }

            DwellerItem item2 = new DwellerItem(EItemType.Weapon, weapon.GetAsDwellerItem().Id);
            MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
        }

        public static void GetBestOutfit(Menu m)
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

        public static void GetLegendaryWeapons(Menu m)
        {
            if (!MonoSingleton<GameParameters>.IsInstanceValid && !MonoSingleton<Vault>.IsInstanceValid) return;
            foreach (DwellerWeaponItem wep in MonoSingleton<GameParameters>.Instance.Items.WeaponsList)
            {
                if (wep.ItemRarity == EItemRarity.Legendary)
                {
                    DwellerItem item2 = new DwellerItem(EItemType.Weapon, wep.GetAsDwellerItem().Id);
                    MonoSingleton<Vault>.Instance.Inventory.AddItem(item2);
                }
            }
        }

        public static void GetLegendaryOutfits(Menu m)
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
