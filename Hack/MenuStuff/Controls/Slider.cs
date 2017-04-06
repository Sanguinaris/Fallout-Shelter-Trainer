using System;
using UnityEngine;

namespace PPFalloutShellterTrn.Hack.MenuStuff.Controls
{
    class Slider : Control
    {
        public Slider(float minimValue = 0, float maximValue = 1)
        {
            type = ControlType.Slider;
            Position = new Rect(0, 0, 160, 40);
            maxValue = maximValue;
            minValue = minimValue;
            curValue = minimValue;
        }

        public override void OnDraw()
        {
            curValue = GUI.HorizontalSlider(Position, curValue, minValue, maxValue);
            GUI.Label(new Rect(0, Position.y + 10, Position.width, Position.height), Math.Round(curValue).ToString());
        }

        public override void OnUpdate()
        {
            if(curValue != lastValue)
            {
                lastValue = curValue;
                OnValueChanged?.Invoke(parentMenu);
            }
        }

        public float getValue()
        {
            return curValue;
        }

        public void setValue(float value)
        {
            curValue = value;
        }

        public void setOnValueChanged(Action<Menu> funk)
        {
            OnValueChanged = funk;
        }

        float minValue = 0;
        float maxValue = 1;
        float curValue = 0;
        float lastValue;
        Action<Menu> OnValueChanged;
    }
}
