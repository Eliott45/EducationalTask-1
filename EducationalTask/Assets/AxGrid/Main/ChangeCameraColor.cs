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

        private void ChangeColor()
        {
            var newColor = Settings.Fsm.CurrentStateName switch
            {
                "Ready" => _idleState,
                "Job" => _jobState,
                "Shop" => _shopState, 
                _ => throw new ArgumentOutOfRangeException()
            };
            if (Camera.main is { }) Camera.main.backgroundColor = newColor;
        } 
    }
}
