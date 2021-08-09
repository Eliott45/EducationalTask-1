using AxGrid.Base;
using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace AxGrid.Main.States
{
    [State("Job")]
    public class JobState : FSMState
    {
        [Enter]
        public void Enter()
        {
            Settings.GlobalModel.EventManager.Invoke("Move");
        }
        
        [Bind]
        public void OnBtn(string name)
        {
            switch (name)
            {
                case "Idle":
                    Parent.Change("Ready");
                    break;
                case "Shop":
                    Parent.Change("Shop");
                    break;
            }
        }
        
        [Loop(0.5f, 1f)]
        public void Working()
        {
            Settings.Model.Inc("Money");
        }
    }
}
