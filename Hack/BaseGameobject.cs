using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//TODO add rest of the gui functions 
//TODO add gui skin
//TODO add some comments for dem nubz
//TODO consider action array inside controls

namespace PPFalloutShellterTrn.Hack
{
    class BaseGameobject : MonoBehaviour
    { 
        private void Start()
        {
            //Will be executed on Object generation
            //Initializing Managers
            Managers.EventMgr.Reset();
            Managers.MenuMgr.Reset();
        }

        private void Update()
        {
            //Will be called each update
            Managers.EventMgr.InvokeEvent(Managers.Events.OnUpdate);
        }

        private void OnGUI()
        {
            //Will be called on the drawingz
            GUI.Label(new Rect(10, 10, 180, 20), "Loadsads");
            Managers.EventMgr.InvokeEvent(Managers.Events.OnGui);   //Invokes the gui event 
        }
    }
}
