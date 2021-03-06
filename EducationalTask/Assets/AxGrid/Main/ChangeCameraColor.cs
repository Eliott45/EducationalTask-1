using System;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

namespace AxGrid.Main
{
    public class ChangeCameraColor : MonoBehaviourExtBind
    {

        [Bind("OnColorChanged")]
        private void ChangeColor()
        {
            var newColor = Settings.GlobalModel.Get("Color") switch
            {
                EColors.White => EColors.White.GetColor(),
                EColors.Blue => EColors.Blue.GetColor(),
                EColors.Green => EColors.Green.GetColor(),
                _ => Color.black
            };
            if (Camera.main is { }) Camera.main.backgroundColor = newColor;

        } 
        

    }
}
