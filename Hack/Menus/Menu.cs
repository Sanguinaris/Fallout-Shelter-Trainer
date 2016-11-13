using FSHack.Hack.Managers;
using FSHack.Hack.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FSHack.Hack.Menus
{
    class Menu
    {
        private string menuName;
        private KeyCode menuKey;
        private Categories menuCategory;

        protected Menu(string name, KeyCode code, Categories category)
        {
            this.menuName = name;
            this.menuKey = code;
            this.menuCategory = category;
        }

        public virtual void onStart() { }

        public virtual void onUpdate() { }

        private float scrollValue = 0;

        private float orginalWidth = 640;
        private float orginalHeight = 400;

        public virtual void drawGui() {
            resetDrawMath();
            Vector3 scale;
            scale.x = Screen.width / orginalWidth;
            scale.y = Screen.height / orginalHeight;
            scale.z = 1;

            Matrix4x4 origMatrix = GUI.matrix;
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

            GUI.Box(new Rect(230, 0, 170, 400), this.getMenuName());
            GUI.Box(new Rect(230, 0, 170, 400), this.getMenuName());
            GUI.Box(new Rect(230, 0, 170, 400), this.getMenuName());
            GUI.Box(new Rect(230, 0, 170, 400), this.getMenuName());
            incrementY(8);
            scrollValue = GUI.VerticalScrollbar(new Rect(400, 0, 100, 400), scrollValue, 1.0f, 0, (oldY - 400 + curY > 0) ? oldY - 400 + curY: 0);

            GUI.BeginGroup(new Rect(240, curY, 160, (400 - curY)));
            foreach (Module mod in ModMgr.Instance.getAllMods())
            {
                if (mod.getCategory() != this.menuCategory)
                    continue;

                switch(mod.getGuiElement())
                {
                    case GuiNames.Button:
                        if (GUI.Button(new Rect(0, curY - scrollValue, 160, 40), mod.getName()))
                            mod.onButtonPress();
                        incrementY(2);
                        break;
                    case GuiNames.ButtonWSlider:
                        if (GUI.Button(new Rect(0, curY - scrollValue, 160, 80 / 2), mod.getName() + ": " + mod.sliderValue.ToString()))
                            mod.onButtonPress();
                        incrementY(2);
                        mod.sliderValue = GUI.HorizontalSlider(new Rect(0, curY - scrollValue, 160, 80 / 4), (int)mod.sliderValue, mod.minSliderValue, mod.maxSliderValue);
                        incrementY(4);
                        break;
                    case GuiNames.ButtonWText:
                        mod.textBoxString = GUI.TextField(new Rect(150, curY - scrollValue, 80, 80 / 4), mod.textBoxString);
                        if (GUI.Button(new Rect(0, curY - scrollValue, 80, 80 / 2), mod.getName()))
                            mod.onButtonPress();
                        incrementY(2);
                        break;
                    case GuiNames.Toggle:
                        mod.setState(GUI.Toggle(new Rect(0, curY - scrollValue, 160, 80 / 5), mod.getState(), mod.getName()));
                        incrementY(5);
                        break;

                    case GuiNames.GridSelection:
                        float height = 400 - curY - 12;
                        float heightOfStuff = mod.getGridCount()  / 2 * (80 / 4);
                        mod.curSelectedGrid = GUI.SelectionGrid(new Rect(0, curY, 160, height), mod.curSelectedGrid, mod.getGridNames((int)(scrollValue * 2)), 2);
                        curY += height + 12;
                        break;
                }
            }
            GUI.EndGroup();
            GUI.matrix = origMatrix;
        }

        public string getMenuName() { return this.menuName; }
        public KeyCode getMenuBind() { return this.menuKey; }
        public void setMenuBind(KeyCode key) { this.menuKey = key; }
        public Categories getCategory() { return this.menuCategory; }



        //Drawing Stuff
        protected float curX = 0, curY = 0, normPad = 0, normWidth = 0, normHeight = 0, oldY = 0;
        protected void resetDrawMath() { oldY = curY; curX = Screen.width * 3 / 8;  curY = 0; normPad = Screen.height / 100; normWidth = Screen.width / 4; normHeight = Screen.height / 5; }
        protected void incrementY(float divider) { curY += 80 / divider + 12; }
    }
}

