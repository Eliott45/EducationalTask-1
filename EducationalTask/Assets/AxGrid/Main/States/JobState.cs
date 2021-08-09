using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace AxGrid.Main.States
{
    [State("Job")]
    public class JobState : FSMState
    {
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
    }
}
