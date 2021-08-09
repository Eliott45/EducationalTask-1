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
            Settings.GlobalModel.Set("Color",EColors.White);
            Settings.GlobalModel.Set("BtnIdleEnable", false);
            Settings.GlobalModel.Set("BtnShopEnable", true);
            Settings.GlobalModel.Set("BtnJobEnable", true);
            Settings.GlobalModel.EventManager.Invoke("Move");
            Settings.GlobalModel.EventManager.Invoke("ChangeColor");
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
