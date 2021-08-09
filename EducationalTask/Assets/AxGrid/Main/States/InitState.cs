using AxGrid.FSM;

namespace AxGrid.Main.States
{
    [State("Init")]
    public class InitState : FSMState
    {
        
        [Enter]
        public void Enter()
        {
            Settings.Model.Set("Money",5);

            Parent.Change("Ready");
        }

        
        
    }
}