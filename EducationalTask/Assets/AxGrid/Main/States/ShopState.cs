using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace AxGrid.Main.States
{
    [State("Shop")]
    public class ShopState : FSMState
    {
        [Bind]
        public void OnBtn(string name)
        {
            switch (name)
            {
                case "Idle":
                    Parent.Change("Idle");
                    break;
                case "Job":
                    Parent.Change("Job");
                    break;
            }
        }
    }
}
