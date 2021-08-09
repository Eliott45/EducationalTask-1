using System;
using AxGrid.Base;
using UnityEngine;

namespace AxGrid.Main
{
    public class Buttons : MonoBehaviourExt
    {
        [Header("Set in Inspector:")] 
        [SerializeField] private GameObject _idleButton;
        [SerializeField] private GameObject _jobButton;
        [SerializeField] private GameObject _shopButton;
        
        private GameObject[] _buttons;
        
        [OnAwake]
        private void StartAwake()
        {
            Settings.GlobalModel.EventManager.AddAction("BlockButton", BlockButton);
            _buttons = new[] {_idleButton, _jobButton, _shopButton};
        }
        
        private void BlockButton()
        {
            var button = Settings.Fsm.CurrentStateName switch
            {
                "Ready" => _idleButton,
                "Job" => _jobButton,
                "Shop" => _shopButton, 
                _ => throw new ArgumentOutOfRangeException()
            };
            foreach(var but in _buttons)
            {
                but.SetActive(true);
            }
            button.SetActive(false);
        } 
    }
}
