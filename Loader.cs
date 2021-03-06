﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PPFalloutShellterTrn
{
    public class LoaderExecuter : SplashScreen	//FOR ILPatcher
    {
        protected override void Start()
        {
            Loader.Load();
            base.Start();
        }
    }

    public class Loader
    {
        private static bool wasInit = false;

        public static void Load()
        {
            if (wasInit) return;
            GameObject hackObject = new GameObject();
            hackObject.AddComponent<Hack.BaseGameobject>();
            UnityEngine.Object.DontDestroyOnLoad(hackObject);
            wasInit = true;
        }
    }
}
