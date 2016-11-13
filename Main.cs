using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//HOOK IN AudioScript

namespace FSHack
{
    public class Main
    {
        private static bool wasInit = false;

        public static void Load()
        {
            if (wasInit) return;
            wasInit = true;
            GameObject gameObject = new GameObject();   //An object
            gameObject.AddComponent<Hack.Base>();            //which we add our class to
            UnityEngine.Object.DontDestroyOnLoad(gameObject);//and which shouldnt get destroyed
        }
    }
}
