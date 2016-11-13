using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FSHack.Hack.Menus;

namespace FSHack.Hack.Managers
{
    class MenuMgr
    {
        private List<Menu> menuList = new List<Menu>();
        private int curActiveMenu = -1;

        static readonly MenuMgr _instance = new MenuMgr();

        public static MenuMgr Instance
        {
            get
            {
                return _instance;
            }
        }

        public MenuMgr()
        {
            menuList.Add(new VaultMenu());
            menuList.Add(new DwellerMenu());
            menuList.Add(new InventoryMenu());
            menuList.Add(new RandomEventMenu());
            menuList.Add(new MenuSelection());
        }

        public void onStart()
        {
            foreach(Menu menu in menuList)
            {
                menu.onStart();
            }
        }

        bool wasMenuOn = false;

        public void onUpdate()
        {
            for(int i = 0; i < menuList.Count; i++)
            {
                if(Input.GetKeyDown(menuList[i].getMenuBind()))
                {
                    if (i == curActiveMenu)
                        curActiveMenu = -1;
                    else
                        this.curActiveMenu = i;
                }

                menuList[i].onUpdate();
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                curActiveMenu = -1;
            }

            if(curActiveMenu >= 0)
            {
                wasMenuOn = true;
                if (MonoSingleton<VaultGUIManager>.IsInstanceValid)
                {
                    MonoSingleton<VaultGUIManager>.Instance.BlockInput(true);
                }
            }else if(wasMenuOn)
            {
                wasMenuOn = false;
                if (MonoSingleton<VaultGUIManager>.IsInstanceValid)
                {
                    MonoSingleton<VaultGUIManager>.Instance.BlockInput(false);
                }
            }
        }

        public void onGUI()    //if cant get overriden then use another fúnc name
        {
            if (curActiveMenu >= 0)
                menuList[curActiveMenu].drawGui();
        }

        public Menu getModuleByName(string name)
        {
            foreach (Menu menu in menuList)
            {
                if (menu.getMenuName() == name)
                    return menu;
            }
            return null;
        }

        public List<Menu> getAllMods()
        {
            return menuList;
        }

        public Menu getCurActiveMenu()
        {
            if (curActiveMenu < 0)
                return null;
            return menuList[curActiveMenu];
        }

        public int getCurActiveMenuIdx()
        {
            return curActiveMenu;
        }

        public void setActiveMenu(Menu menu)
        {
            for(int i = 0; i < menuList.Count; i++)
            {
                if (menuList[i] == menu)
                    curActiveMenu = i;
            }
        }

        public void setActiveMenu(int idx)
        {
            if(idx < menuList.Count && idx > -2)
            {
                curActiveMenu = idx;
            }
        }

        public Menu getMenuByCategory(Categories category)
        {
            foreach(Menu menu in menuList)
            {
                if (menu.getCategory() == category)
                    return menu;
            }
            return null;
        }

        public int getModuleListCount()
        {
            return menuList.Count;
        }
    }
}
