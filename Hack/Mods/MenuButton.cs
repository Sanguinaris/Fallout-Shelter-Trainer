using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;
using FSHack.Hack.Menus;

namespace FSHack.Hack.Mods
{
    class MenuButton : Module
    {
        public MenuButton() : base("Open Menu", KeyCode.None, Categories.mNone, GuiNames.Button)
        {
            EventMgr.Instance.registerEventListener(EventNames.onRender, this);
        }

        private float orginalWidth = 640;
        private float orginalHeight = 400;

        public override void onDraw()
        {
            Vector3 scale;
            scale.x = Screen.width / orginalWidth;
            scale.y = Screen.height / orginalHeight;
            scale.z = 1;

            Matrix4x4 origMatrix = GUI.matrix;
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
            if (GUI.Button(new Rect(0,150,100,100), base.getName()))
            {
                Menu menu = MenuMgr.Instance.getMenuByCategory(Categories.mMenus);
                if(menu != null)
                {
                    if (MenuMgr.Instance.getCurActiveMenuIdx() == -1)
                        MenuMgr.Instance.setActiveMenu(menu);
                    else
                        MenuMgr.Instance.setActiveMenu(-1);
                }
            }

            GUI.matrix = origMatrix;
        }
    }
}
