using PPFalloutShellterTrn.Hack.MenuStuff;
using PPFalloutShellterTrn.Hack.MenuStuff.Controls;
using PPFalloutShellterTrn.Hack.MenuStuff.ModMenus;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace PPFalloutShellterTrn.Hack.Modules
{
    class VaultMods
    {
        public static bool CanRemoveAllRooms = false;
        public static void ToggleRoomHack(Menu m)
        {
            CanRemoveAllRooms = !CanRemoveAllRooms;
        }

        public static void InfiniteEnergy(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            MonoSingleton<Vault>.Instance.Storage.AddResource(new GameResources(EResource.Energy, 1337));
        }

        public static void InfiniteFood(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            MonoSingleton<Vault>.Instance.Storage.AddResource(new GameResources(EResource.Food, 1337));
        }

        public static void InfiniteNuka(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            MonoSingleton<Vault>.Instance.Storage.AddResource(new GameResources(EResource.Nuka, 1337));
        }


        public static void InfiniteRadAway(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            MonoSingleton<Vault>.Instance.Storage.AddResource(new GameResources(EResource.RadAway, 1337));
        }

        public static void InfiniteStimPacks(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            MonoSingleton<Vault>.Instance.Storage.AddResource(new GameResources(EResource.StimPack, 1337));
        }

        public static void InfiniteWater(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            MonoSingleton<Vault>.Instance.Storage.AddResource(new GameResources(EResource.Energy, 1337));
        }

        public static void RemoveRocks(Menu m)
        {

        }

        private static int OldMaxDwellers = 0;
        public static void UnlimitedDwellersEnable(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            OldMaxDwellers = MonoSingleton<Vault>.Instance.MaxDwellers;
        }
        public static void UnlimitedDwellersDisable(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
            MonoSingleton<Vault>.Instance.MaxDwellers = OldMaxDwellers;
        }
        public static void UnlimitedDweller(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;

            if (OldMaxDwellers == 0)
                OldMaxDwellers = MonoSingleton<Vault>.Instance.MaxDwellers;

            MonoSingleton<Vault>.Instance.MaxDwellers = 133333337;
        }

        public static void UnlockRooms(Menu m)
        {
            if (!MonoSingleton<VaultGUIManager>.IsInstanceValid) return;
            foreach (ERoomType room in Enum.GetValues(typeof(ERoomType)))
                MonoSingleton<VaultGUIManager>.Instance.m_RoomsBuildWindow.Cheat_UnlockRoom(room);
        }

        public static void UnlockThemes(Menu m)
        {
            if (!MonoSingleton<VaultGUIManager>.IsInstanceValid || !MonoSingleton<GameParameters>.IsInstanceValid) return;
            foreach (ESpecialTheme theme in Enum.GetValues(typeof(ESpecialTheme)))
                foreach (ERoomType room in Enum.GetValues(typeof(ERoomType)))
                    MonoSingleton<VaultGUIManager>.Instance.m_survivalWindow.CollectedThemes.CraftTheme(room, theme);
            MonoSingleton<GameParameters>.Instance.Items.CraftParameters.ReInitializeCachedRecipesOnce();
        }
    }

    class FuckLogs : Game.Standalone.Rest.Api.Bnet.BnetManager
    {	//ALSO NOP OUT LOG WHITELIST (SEARCH FOR WHITELIST THERE SHOULD BE A FUNCTION IN THERE INTERFACING THE WHITELIST OF LOGABLE STUFF)
        public FuckLogs(GameObject parent) : base(parent)
        {
        }

        public override void LogSwrveEvent(string name, string eventName, Dictionary<string, string> payload = null)
        {
        }
    }

    class RemoveableRooms : Room
    {
        protected override bool RoomCanDoAction(ERoomAction action, Dweller dweller = null)
        {
            if (action == ERoomAction.DestroyRoom && VaultMods.CanRemoveAllRooms)
                return true;
            return base.RoomCanDoAction(action, dweller);
        }
    }
}
