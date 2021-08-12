using AxGrid.FSM;
using AxGrid.Main;
using AxGrid.Model;
using UnityEngine;
using AxGrid.Base;

namespace AxGrid.TestDropdown.States
{
    [State("Ready")]
    public class ReadyState : FSMState
    {
        [Enter]
        public void Enter()
        {
            
        }

        [Bind("OnDropdownChanged")]
        public void Print()
        {
            Debug.Log($"Value changed: {Model.GetString("DifficultSelect")}");
        }
        
    }
}
