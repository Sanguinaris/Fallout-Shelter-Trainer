using PPFalloutShellterTrn.Hack.Managers;
using PPFalloutShellterTrn.Hack.MenuStuff.Controls;
using PPFalloutShellterTrn.Hack.Modules;
using UnityEngine;

namespace PPFalloutShellterTrn.Hack.MenuStuff.ModMenus	//DAT NAMING DOE
{
    class VaultMenu : Menu
    {
        CheckBox CanRemoveEveryRoom = new CheckBox("Make Every Room Removeable");

        CheckBox InfiniteEnergy = new CheckBox("Infinite Energy");
        CheckBox InfiniteFood = new CheckBox("Infinite Food");
        CheckBox InfiniteNuka = new CheckBox("Infinite Nuka");
        CheckBox InfiniteNukaQuantum = new CheckBox("Infinite Nuka Quantum");
        CheckBox InfiniteRadAway = new MenuStuff.Controls.CheckBox("Infinite RadAway");
        CheckBox InfiniteStimPacks = new MenuStuff.Controls.CheckBox("Infinite Stim Packs");
        CheckBox InfiniteWater = new MenuStuff.Controls.CheckBox("Infintie Water");

        Button RemoveRocks = new Button("Remove Rocks");
        CheckBox UnlimitedDwellers = new MenuStuff.Controls.CheckBox("Unlimited Dwellers");
        Button UnlockRooms = new Button("Unlock Rooms");
        Button UnlockThemes = new Button("Unlock Themes");

        public VaultMenu() : base("Vault Menu", KeyCode.Alpha1)	//Dunno why there is menutype rn
        {
        }

        public override void OnInit()
        {
            CanRemoveEveryRoom.setOnToggle(VaultMods.ToggleRoomHack);
            RegisterControl(CanRemoveEveryRoom);

            RegisterControl(InfiniteEnergy, VaultMods.InfiniteEnergy);
            RegisterControl(InfiniteFood, VaultMods.InfiniteFood);
            RegisterControl(InfiniteNuka, VaultMods.InfiniteNuka);
            RegisterControl(InfiniteNukaQuantum, VaultMods.InfiniteNukaQuantum);
            RegisterControl(InfiniteRadAway, VaultMods.InfiniteRadAway);
            RegisterControl(InfiniteStimPacks, VaultMods.InfiniteStimPacks);
            RegisterControl(InfiniteWater, VaultMods.InfiniteWater);

            RegisterControl(RemoveRocks, VaultMods.RemoveRocks);

            UnlimitedDwellers.setOnEnable(VaultMods.UnlimitedDwellersEnable);
            UnlimitedDwellers.setOnDisable(VaultMods.UnlimitedDwellersDisable);
            RegisterControl(UnlimitedDwellers, VaultMods.UnlimitedDweller);

            RegisterControl(UnlockRooms, VaultMods.UnlockRooms);
            RegisterControl(UnlockThemes, VaultMods.UnlockThemes);

            base.OnInit();
        }
    }

    class DwellerMenu : Menu
    {
        CheckBox GodMode = new CheckBox("God Mode");
        CheckBox AlwaysCriticals = new CheckBox("Always Criticals");
        CheckBox AlwaysHappy = new CheckBox("Always Happy");
        Button LevelAllUp = new Button("Level All Up");
        public Slider LevelUpAmount = new Slider(1, 50);
        Button MakeSpecial = new Button("Make Everyone Special");
        Button MassAbortion = new Button("Mass Abortion");
        Button MassPregnancy = new Button("Mass Pregnancy");
        Button SpawnDweller = new Button("Spawn Dweller");

        public DwellerMenu() : base("Dweller Menu", KeyCode.Alpha2)
        {
        }

        public override void OnInit()
        {
            RegisterControl(GodMode, DwellerMods.GodMode);
            RegisterControl(AlwaysCriticals, DwellerMods.AlwaysCrits);
            RegisterControl(AlwaysHappy, DwellerMods.AlwaysHappy);
            RegisterControl(LevelAllUp, DwellerMods.LevelUpAll);
            RegisterControl(LevelUpAmount);
            RegisterControl(MakeSpecial, DwellerMods.EverybodyIsSpecial);
            RegisterControl(MassAbortion, DwellerMods.MassAbortions);
            RegisterControl(MassPregnancy, DwellerMods.MassPregnancy);
            RegisterControl(SpawnDweller, DwellerMods.SpawnDweller);
 
            base.OnInit();
        }
    }

    class InventoryMenu : Menu
    {
        CheckBox UnlimitedStorage = new CheckBox("Unlimited Storage");
        Button GetAllItems = new Button("Get All");
        Button RemoveAllItems = new Button("Remove All");

        Button GetBestWeapon = new Button("Get Best Weapon");
        Button GetBestOutfit = new Button("Get Best Outfit");

        Button GetEveryLegendaryWeapon = new Button("Get Every Legendary Weapon");
        Button GetEveryLegendaryOutfit = new Button("Get Every Legendary Outfit");

        Button GetAllWeapons = new Button("Get All Weapons");
        Button GetAllOutfits = new Button("Get All Outfits");
        Button GetAllJunks = new Button("Get All Junk");

        public InventoryMenu() : base("Inventory Menu", KeyCode.Alpha3)
        {
        }

        public override void OnInit()
        {
            UnlimitedStorage.setOnEnable(InventoryMods.UnlimitedStorageEnable);
            UnlimitedStorage.setOnDisable(InventoryMods.UnlimitedStorageDisable);

            RegisterControl(UnlimitedStorage, InventoryMods.UnlimitedStorage);

            RegisterControl(GetAllItems, InventoryMods.GetAll);
            RegisterControl(RemoveAllItems, InventoryMods.RemoveAll);

            RegisterControl(GetBestOutfit, InventoryMods.GetBestOutfit);
            RegisterControl(GetBestWeapon, InventoryMods.GetBestWeapon);

            RegisterControl(GetEveryLegendaryOutfit, InventoryMods.GetLegendaryOutfits);
            RegisterControl(GetEveryLegendaryWeapon, InventoryMods.GetLegendaryWeapons);

            RegisterControl(GetAllWeapons, InventoryMods.GetAllWeapons);
            RegisterControl(GetAllOutfits, InventoryMods.GetAllOutfits);
            RegisterControl(GetAllJunks, InventoryMods.GetAllJunk);
            base.OnInit();
        }
    }

    class RandomEventsMenu : Menu
    {
        CheckBox NoRandomEvents = new CheckBox("No Random Events");
        CheckBox RushAlwaysSucceeds = new CheckBox("Rush Always Succeeds");

        Button BeginDeathClawAttack = new Button("Begin Deathclaw Attack");
        Button BeginGhoulAttack = new Button("Begin Ghoul Attack");
        Button BeginRaid = new Button("Begin Raid");


        public RandomEventsMenu() : base("Random Event Menu", KeyCode.Alpha4)
        {
        }

        public override void OnInit()
        {
            RegisterControl(NoRandomEvents, RandomEventMods.NoRandomEvents);
            RushAlwaysSucceeds.setOnToggle(RandomEventMods.RushAlwaysWinsToggle);
            RegisterControl(RushAlwaysSucceeds);

            RegisterControl(BeginDeathClawAttack, RandomEventMods.BeginDeathClawAtk);
            RegisterControl(BeginGhoulAttack, RandomEventMods.BeginGhoulAtk);
            RegisterControl(BeginRaid, RandomEventMods.BeginRaid);

            base.OnInit();
        }
    }
}
