using AxGrid.FSM;
using AxGrid.Main;
using AxGrid.Model;
using UnityEngine;

namespace AxGrid.TestDropdown.States
{
    [State("Ready")]
    public class ReadyState : FSMState
    {
        [Enter]
        public void Enter()
        {
            Settings.Model.Set("Option", Settings.Model.GetList<string>("Options")[0]);
        }
        
        [Bind]
        public void OnSelect(string name, int option)
        {
            switch (name)
            {
                case "Dropdown":
                    Settings.Model.Set("Option", Settings.Model.GetList<string>("Options")[option]);
                    Debug.Log(Settings.Model.GetString("Option"));
                    break;
            }
        }
    }
}
