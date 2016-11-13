using FSHack.Hack.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FSHack.Hack.Mods.MenuMods
{
    class RandomEventMenuBtn : Module
    {
        public RandomEventMenuBtn() : base("Random Events Menu", KeyCode.None, Categories.mMenus, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            MenuMgr.Instance.setActiveMenu(MenuMgr.Instance.getMenuByCategory(Categories.mRandomEvents));
        }
    }
}
