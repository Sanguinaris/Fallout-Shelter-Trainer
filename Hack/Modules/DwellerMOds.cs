using PPFalloutShellterTrn.Hack.MenuStuff;
using PPFalloutShellterTrn.Hack.MenuStuff.ModMenus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPFalloutShellterTrn.Hack.Modules
{
    class DwellerMods
    {
        public static void GodMode(Menu m)
        {
            if (MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach (Dweller inh in MonoSingleton<DwellerManager>.Instance.Dwellers)
                    if (!inh.IsRaider)
                        inh.Health.ChangeHealth(inh.Health.HealthMax);
        }

        public static void AlwaysCrits(Menu m)
        {
            if (MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach (Dweller inh in MonoSingleton<DwellerManager>.Instance.Dwellers)
                    if (!inh.IsRaider)
                        inh.IncreaseCriticalHitMeter();
        }

        public static void AlwaysHappy(Menu m)
        {
            if (MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach (Dweller inh in MonoSingleton<DwellerManager>.Instance.Dwellers)
                    inh.Happiness.AddHappiness(1337);
        }

        public static void LevelUpAll(Menu m)
        {
            if (MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach (Dweller inh in MonoSingleton<DwellerManager>.Instance.Dwellers)
                    if (!inh.IsRaider)
                        for(int i = 0; i < ((DwellerMenu)m).LevelUpAmount.getValue(); i++)
                            inh.Experience.LevelUP();
        }

        public static void EverybodyIsSpecial(Menu m)
        {
            if (MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach (Dweller inh in MonoSingleton<DwellerManager>.Instance.Dwellers)
                {
                    if (inh.IsRaider) continue;
                    inh.Stats.GetStat(ESpecialStat.Agility).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Charisma).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Endurance).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Intelligence).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Luck).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Perception).IncreaseBaseValue(100);
                    inh.Stats.GetStat(ESpecialStat.Strength).IncreaseBaseValue(100);
                }
        }

        public static void MassAbortions(Menu m)
        {
            if (MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach (Dweller inh in MonoSingleton<DwellerManager>.Instance.Dwellers)
                    inh.SetPregnant(false);
        }

        public static void MassPregnancy(Menu m)
        {
            if (MonoSingleton<DwellerManager>.IsInstanceValid)
                foreach (Dweller inh in MonoSingleton<DwellerManager>.Instance.Dwellers)
                    inh.SetPregnant(true);
        }

        public static void SpawnDweller(Menu m)
        {
            if (MonoSingleton<DwellerSpawner>.IsInstanceValid)
                MonoSingleton<DwellerSpawner>.Instance.CreateWaitingDweller(EGender.Any, false, 0, EDwellerRarity.Legendary);
        }
    }
}
