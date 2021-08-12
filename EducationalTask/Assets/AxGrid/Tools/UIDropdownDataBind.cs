using System.Collections.Generic;
using AxGrid.Base;
using UnityEngine;
using UnityEngine.UI;

namespace AxGrid.Tools
{
    [RequireComponent(typeof(Dropdown))]
    public class UIDropdownDataBind : Binder
    {
        [Header("Set in Inspector")]
        public string dropdownName = "";
        
        private Dropdown _dropdown;

        [OnAwake]
        public void StartAwake()
        {
            _dropdown = GetComponent<Dropdown>();
            
            if (string.IsNullOrEmpty(dropdownName)) dropdownName = name;

            _dropdown.onValueChanged.AddListener(delegate { OnSelect(); });
        }

        [OnStart]
        public void StartStart()
        {
            FillOptions(Settings.Model.GetList<string>("Options"));
        }
        
        [OnDestroy]
        public void StartDestroy()
        {
            _dropdown.onValueChanged.RemoveAllListeners();
        }
        
        private void OnSelect()
        {
            if (!_dropdown.interactable || !isActiveAndEnabled) return;
            
            Settings.Fsm?.Invoke("OnSelect", dropdownName, _dropdown.value);
            Model?.EventManager.Invoke($"On{dropdownName}Select");
        }

        private void FillOptions(List<string> options)
        {
            _dropdown.ClearOptions();
            foreach (var option in options)
            {
                _dropdown.options.Add(new Dropdown.OptionData {text = option});
            }
            
            // _dropdown.value = 1;
        }
    }
}
