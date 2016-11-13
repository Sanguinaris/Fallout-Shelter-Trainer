using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSHack.Hack.Managers;
using UnityEngine;

namespace FSHack.Hack.Menus
{
    class InventoryMenu : Menu
    {
        public InventoryMenu() : base("Inventory Menu", KeyCode.Alpha3, Categories.mInventory)
        {
        }
    }
}
