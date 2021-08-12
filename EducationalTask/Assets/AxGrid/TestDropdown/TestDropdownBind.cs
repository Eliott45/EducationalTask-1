using AxGrid.Base;
using AxGrid.TestDropdown.States;
using UnityEngine;

namespace AxGrid.TestDropdown
{
    public class TestDropdownBind : MonoBehaviourExt
    {
        [OnAwake]
        public void Init()
        {
            Settings.Fsm = new FSM.FSM(); 
            Settings.Fsm.Add(new InitState()); 
            Settings.Fsm.Add(new ReadyState());
        }
        
        [OnStart]
        // ReSharper disable once InconsistentNaming
        public void StartFSM()
        {
            Settings.Fsm.Start("Init");
        }

        [OnUpdate]
        // ReSharper disable once InconsistentNaming
        public void UpdateFSM()
        {
            Settings.Fsm.Update(Time.deltaTime);
         
        }
    }
}
