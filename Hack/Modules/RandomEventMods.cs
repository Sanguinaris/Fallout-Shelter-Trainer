using PPFalloutShellterTrn.Hack.MenuStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PPFalloutShellterTrn.Hack.Modules
{
    class RandomEventMods
    {
       public static void NoRandomEvents(Menu m)
        {
            if (MonoSingleton<Vault>.IsInstanceValid)
                MonoSingleton<Vault>.Instance.EmergencyState.Clean();
        }

        public static bool shouldAlwaysSucceed = false;
        public static void RushAlwaysWinsToggle(Menu m)
        {
            shouldAlwaysSucceed = !shouldAlwaysSucceed;
        }

        public static void BeginDeathClawAtk(Menu m)
        {
            if (MonoSingleton<Vault>.IsInstanceValid)
                MonoSingleton<Vault>.Instance.EmergencyState.DeathclawMgr.BeginAttack();
        }

        public static void BeginGhoulAtk(Menu m)
        {
            if (MonoSingleton<Vault>.IsInstanceValid)
                MonoSingleton<Vault>.Instance.EmergencyState.GhoulMgr.BeginAttack();
        }

        public static void BeginRaid(Menu m)
        {
            if (!MonoSingleton<Vault>.IsInstanceValid) return;
                MonoSingleton<Vault>.Instance.EmergencyState.RaiderMgr.BeginAttack();
        }
    }

    class RushHack : ProductionRoom
    {
        public override RoomRushData GetRushData()
        {
            if(!RandomEventMods.shouldAlwaysSucceed)
                return base.GetRushData();

            RoomRushData data = new RoomRushData();
            RoomParameters room = MonoSingleton<GameParameters>.Instance.Room;
            data.DisasterTier = Mathf.CeilToInt(((float)base.GetRushTimerRemainingTime().Time) / room.RushTimerIncreasePerRush);
            data.DisasterChance = 0;
            data.ExpMod = this.m_bonusExpBase + (data.DisasterTier * room.RushExpModPerTier);
            data.ResMod = this.m_bonusResourcesBase + (data.DisasterTier * room.RushResourceModPerTier);
            return data;
        }
    }
}
