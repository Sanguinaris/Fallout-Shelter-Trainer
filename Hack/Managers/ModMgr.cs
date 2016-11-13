using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Mods;
using UnityEngine;
using FSHack.Hack.Mods.VaultMods;
using FSHack.Hack.Mods.DwellerMods;
using FSHack.Hack.Mods.RandomEventMods;
using FSHack.Hack.Mods.InventoryMods;
using FSHack.Hack.Mods.MenuMods;

namespace FSHack.Hack.Managers
{
    public enum Categories{
        mNone,
        mVault,
		mDweller,
		mInventory,
        mRandomEvents,
        mMenus
    };

    public enum GuiNames
    {
        None,
        Toggle,
        Button,
        ButtonWSlider,
        ButtonWText,
        GridSelection
    };

    class ModMgr
    {
        static readonly ModMgr _instance = new ModMgr();

        public static ModMgr Instance
        {
            get
            {
                return _instance;
            }
        }

        List<Module> moduleList = new List<Module>();

        public ModMgr()
        {
            moduleList.Add(new MenuButton());
            //Vault Menu
            moduleList.Add(new InfiniteEnergy());
            moduleList.Add(new InfiniteFood());
            moduleList.Add(new InfiniteWater());
            moduleList.Add(new InfiniteStimPacks());
            moduleList.Add(new InfiniteRadAway());
            moduleList.Add(new InfiniteNuka());
            moduleList.Add(new UnlimitedStorageSpace());
            moduleList.Add(new RemoveRocks());
            moduleList.Add(new UnlockRooms());
            moduleList.Add(new UnlockThemes());

            moduleList.Add(new TrumpHeaven());
            moduleList.Add(new HillarysHeaven());

            //Dweller Menu
            moduleList.Add(new GodMode());
            moduleList.Add(new InfiniteHappiness());
            moduleList.Add(new InfiniteCriticalHits());
            moduleList.Add(new UnlimitedDwellers());
            moduleList.Add(new MassPregnancy());
            moduleList.Add(new MassAbort());
            moduleList.Add(new SpawnDweller());
            moduleList.Add(new MakeSpecial());
            moduleList.Add(new LevelAllUp());

            //Random Events
            moduleList.Add(new NoRandomEvents());
            moduleList.Add(new RushAlwaysSucceeds());
            moduleList.Add(new BeginRaid());
            moduleList.Add(new BeginDeathClawAttack());
            moduleList.Add(new BeginGhoulAttack());

            //Inventory
            moduleList.Add(new GetEverything());

            moduleList.Add(new GetAllWeapons());
            moduleList.Add(new GetAllOutfits());
            moduleList.Add(new GetAllJunk());

            moduleList.Add(new GetEveryLegendaryWeapon());
            moduleList.Add(new GetEveryLegendaryOutfit());

            moduleList.Add(new GetBestWeapon());
            moduleList.Add(new GetBestOutfit());

            moduleList.Add(new RemoveAllItems());

            //Menus
            moduleList.Add(new VaultMenuBtn());
            moduleList.Add(new DwellerMenuBtn());
            moduleList.Add(new InventoryMenuBtn());
            moduleList.Add(new RandomEventMenuBtn());
        }

        private void dispatchKeyEvents()
        {
            foreach(Module mod in moduleList)
            {
                if(Input.GetKeyDown(mod.getBind()))
                {
                    mod.toggle();
                }
            }
        }

        public void onUpdate()
        {
            dispatchKeyEvents();
        }

        public Module getModuleByName(string name)
        {
            foreach(Module mod in moduleList)
            {
                if (mod.getName() == name)
                    return mod;
            }
            return null;
        }

        public List<Module> getAllMods()
        {
            return moduleList;
        }

        public int getModuleListCount()
        {
            return moduleList.Count;
        }
    }
}
