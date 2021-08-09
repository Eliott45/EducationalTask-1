using AxGrid.Base;
using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace AxGrid.Main.States
{
    [State("Ready")]
    public class ReadyState : FSMState
    {
        [Enter]
        public void Enter()
        {
            Settings.GlobalModel.EventManager.Invoke("Move");
            Settings.GlobalModel.EventManager.Invoke("ChangeColor");
            Settings.GlobalModel.EventManager.Invoke("BlockButton");
        }
        
        [Bind]
        public void OnBtn(string name)
        {
            switch (name)
            {
                case "Shop":
                    Parent.Change("Shop");
                    break;
                case "Job":
                    Parent.Change("Job");
                    break;
            }
        }
    }
}
