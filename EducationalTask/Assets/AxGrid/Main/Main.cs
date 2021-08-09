using UnityEngine;
using AxGrid.Base;
using AxGrid.Main.States;

namespace AxGrid.Main
{
    public class Main : MonoBehaviourExt
    {
        [OnAwake]
        public void Init()
        {
            Settings.Fsm = new FSM.FSM(); 
            Settings.Fsm.Add(new InitState()); 
            Settings.Fsm.Add(new ReadyState());
            Settings.Fsm.Add(new JobState());
            Settings.Fsm.Add(new ShopState());
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
