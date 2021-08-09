using System;
using AxGrid.Base;
using UnityEngine;

namespace AxGrid.Main
{
    public class ChangeCameraColor : MonoBehaviourExt
    {
        [OnAwake]
        private void StartAwake()
        {
            Settings.GlobalModel.EventManager.AddAction("ChangeColor", ChangeColor);
        }

        private void ChangeColor()
        {
            var newColor = Settings.GlobalModel.Get("Color") switch
            {
                EColors.White => Color.white,
                EColors.Blue => Color.cyan,
                EColors.Green => Color.green,
                _ => Color.black
            };
            if (Camera.main is { }) Camera.main.backgroundColor = newColor;
        } 
        
        [OnDestroy]
        private void Die()
        {
            Settings.GlobalModel.EventManager.RemoveAction(ChangeColor);
        }

    }
}
