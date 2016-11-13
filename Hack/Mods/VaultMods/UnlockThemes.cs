using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.VaultMods
{
    class UnlockThemes : Module
    {
        public UnlockThemes() : base("Unlock Themes", KeyCode.None, Categories.mVault, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            if (!MonoSingleton<VaultGUIManager>.IsInstanceValid && !MonoSingleton<GameParameters>.IsInstanceValid) return;
            foreach (ESpecialTheme themes in Enum.GetValues(typeof(ESpecialTheme))) {

                foreach (ERoomType room in Enum.GetValues(typeof(ERoomType))) {
                    MonoSingleton<VaultGUIManager>.Instance.m_survivalWindow.CollectedThemes.CraftTheme(room, themes);
                }
            }
            MonoSingleton<GameParameters>.Instance.Items.CraftParameters.ReInitializeCachedRecipesOnce();
        }
    }
}
