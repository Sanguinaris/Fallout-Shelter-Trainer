using FSHack.Hack.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FSHack.Hack
{
    public class Base : MonoBehaviour
    {
        private void Start()
        {
            MenuMgr.Instance.onStart();
        }

        private void Update()
        {
            ModMgr.Instance.onUpdate();
            MenuMgr.Instance.onUpdate();
            EventMgr.Instance.onUpdate();
        }

        private void OnGUI()
        {
            //  GUI.color = new Color(255, 255, 0);
            //  GUI.Label(new Rect(10, 10, 130, 20), "PiratePerfection.com");
            //  GUI.color = new Color(255, 255, 255);
            MenuMgr.Instance.onGUI();
            EventMgr.Instance.onRender();
        }
    }
}
