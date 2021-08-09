using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace AxGrid.Main.States
{
    [State("Shop")]
    public class ShopState : FSMState
    {
        [Enter]
        public void Enter()
        {
            Settings.GlobalModel.Set("Color",EColors.Blue);
            Settings.GlobalModel.Set("Action",EStates.shopping);
            Settings.GlobalModel.Set("BtnIdleEnable", true);
            Settings.GlobalModel.Set("BtnShopEnable", false);
            Settings.GlobalModel.Set("BtnJobEnable", true);
        }
        
        [Bind]
        public void OnBtn(string name)
        {
            switch (name)
            {
                case "Idle":
                    Parent.Change("Ready");
                    break;
                case "Job":
                    Parent.Change("Job");
                    break;
            }
        }
        
        [Loop(0.5f,1f)]
        public void Working()
        {
            if (Settings.Model.GetInt("Money", 0) > 0)
            {
                Settings.Model.Dec("Money");
            }
            else
            {
                Parent.Change("Ready");
            }
            
        }
    }
}
