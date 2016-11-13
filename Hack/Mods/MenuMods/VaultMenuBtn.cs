using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Mods.MenuMods
{
    class VaultMenuBtn : Module
    {
        public VaultMenuBtn() : base("Vault Menu", KeyCode.None, Categories.mMenus, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            MenuMgr.Instance.setActiveMenu(MenuMgr.Instance.getMenuByCategory(Categories.mVault));
        }
    }
}
