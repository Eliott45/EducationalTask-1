using System;
using System.Collections.Generic;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

namespace AxGrid.Tools
{
    [RequireComponent(typeof(Dropdown))]
    public class UIDropdownDataBind : Binder
    {
        [Header("Set in Inspector")]
        public string dropdownName = "";
        [SerializeField] private string _nameModelCollection;
        [SerializeField] private string _nameModelOption;
        
        private Dropdown _dropdown;
        private List<string> _modelCollection;
        private string _modelOption;

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
            if (string.IsNullOrEmpty(_nameModelCollection) || string.IsNullOrEmpty(_nameModelOption))
            {
                Debug.LogError("Name of model is empty!");
            }

            _modelCollection = Model.GetList<string>(_nameModelCollection);
            _modelOption = Model.GetString(_nameModelOption);
            FillOptions(_modelCollection, _modelOption);
        }

        [OnEnable]
        public void UpdateData()
        {
            _modelCollection = Model.GetList<string>(_nameModelCollection, new List<string>());
            _modelOption = Model.GetString(_nameModelOption);
            FillOptions(_modelCollection, _modelOption);
        }
        
        [OnDestroy]
        public void StartDestroy()
        {
            _dropdown.onValueChanged.RemoveAllListeners();
        }
        
        private void OnSelect()
        {
            if (!_dropdown.interactable || !isActiveAndEnabled) return;

            SentData();

            Settings.Invoke("OnDropdownChanged", dropdownName);
            
            // Settings.Invoke($"On{_nameModelOption}Changed", dropdownName);
            // Model?.EventManager.Invoke($"On{_dropdownName}Select");
        }
        
        private void FillOptions(List<string> options, string defaultValue)
        {
            _dropdown.ClearOptions();
            
            if (options.Count == 0)
            {
                Debug.LogWarning("Collection is empty!");
                return;
            }
            
            foreach (var option in options)
            {
                _dropdown.options.Add(new Dropdown.OptionData {text = option});
            }

            if (!string.IsNullOrEmpty(defaultValue))
            {
                for (var i = 0; i < options.Count; i++)
                {
                    if (options[i] == defaultValue) _dropdown.value = i;
                }
            }
            else
            {
                _dropdown.value = 0;
            }
            
            _dropdown.RefreshShownValue();
            
            SentData();
        }

        private void SentData() => Model.Set(_nameModelOption, _modelCollection[_dropdown.value]);
        
    }
}
