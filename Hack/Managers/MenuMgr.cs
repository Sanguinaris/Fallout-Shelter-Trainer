using PPFalloutShellterTrn.Hack.MenuStuff;
using PPFalloutShellterTrn.Hack.MenuStuff.ModMenus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PPFalloutShellterTrn.Hack.Managers
{
    //Responsible for showing the right menu
    class MenuMgr
    {

        public static void Reset()
        {
            Menus.Clear();
            EventMgr.DeleteFunc(Events.OnUpdate, OnUpdate);
            EventMgr.DeleteFunc(Events.OnGui, DrawMenu);

            EventMgr.RegisterFunc(Events.OnGui, DrawMenu);
            EventMgr.RegisterFunc(Events.OnUpdate, OnUpdate);

            Menus.Add(new VaultMenu());
            Menus.Add(new DwellerMenu());
            Menus.Add(new InventoryMenu());
            Menus.Add(new RandomEventsMenu());

            foreach (Menu menu in Menus)
            {
                menu.OnInit();
            }
        }

        static bool hadUnlockedView = false;
        private static void SetPauseState(bool state)
        {
            if (!MonoSingleton<VaultGUIManager>.IsInstanceValid) return;
            MonoSingleton<VaultGUIManager>.Instance.BlockInput(state);
            Time.timeScale = (state) ? 0 : 1;
        }

        public static void DrawMenu()
        {
            //Draw stuff
            if(iCurMenu >= 0)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    iCurMenu = -1;
                    SetPauseState(false);
                }

                Menus[iCurMenu].OnDraw();
            }
        }

        public static void OnUpdate()
        {
            for (int i = 0; i < Menus.Count; i++)
            {
                if(Input.GetKeyDown(Menus[i].getKey()))
                {
                    if (i == iCurMenu)
                    {
                        iCurMenu = -1;
                        SetPauseState(false);
                    }
                    else
                    {
                        iCurMenu = i;
                        SetPauseState(true);
                    }
                }

                Menus[i].OnUpdate();
            }
        }

        public static void setCurActiveMenu(int idx)
        {
            iCurMenu = idx;
        }

        public static MenuStuff.Menu getMenuByIdx(int idx)
        {
            return Menus[idx];
        }

        public static MenuStuff.Menu getCurrentMenu()
        {
            if (iCurMenu >= 0)
                return Menus[iCurMenu];
            return null;
        }

        public static int getCurMenuIdx()
        {
            return iCurMenu;
        }

        static List<MenuStuff.Menu> Menus = new List<MenuStuff.Menu>();
        static int iCurMenu = -1;
    }
}
