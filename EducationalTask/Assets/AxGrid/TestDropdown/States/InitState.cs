using System.Collections.Generic;
using AxGrid.FSM;
using UnityEngine;

namespace AxGrid.TestDropdown.States
{
    [State("Init")]
    public class InitState : FSMState
    {
        [Enter]
        public void Enter()
        {
            var options = new List<string> {"Hard", "Normal", "Easy"};
            
            Model.Set("DifficultCollection",options);
            Model.Set("DifficultSelect", "Easy");
            
            Parent.Change("Ready");
        }
    }
}
