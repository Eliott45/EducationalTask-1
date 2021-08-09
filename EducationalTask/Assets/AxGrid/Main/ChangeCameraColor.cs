using System;
using AxGrid.Base;
using UnityEngine;

namespace AxGrid.Main
{
    public class ChangeCameraColor : MonoBehaviourExt
    {
        [Header("Set in Inspector:")] 
        [SerializeField] private Color _idleState;
        [SerializeField] private Color _jobState;
        [SerializeField] private Color _shopState;
        
        [OnAwake]
        private void StartAwake()
        {
            Settings.GlobalModel.EventManager.AddAction("ChangeColor", ChangeColor);
        }

        private static void ChangeColor()
        {
            var newColor = Settings.Model.Get("Color") switch
            {
                EColors.White => Color.white,
                EColors.Blue => Color.cyan,
                EColors.Green => Color.green,
                _ => Color.black
            };
            if (Camera.main is { }) Camera.main.backgroundColor = newColor;
        } 
    }
}
