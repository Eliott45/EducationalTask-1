using AxGrid.FSM;

namespace AxGrid.Main.States
{
    [State("Init")]
    public class InitState : FSMState
    {
        
        [Enter]
        public void Enter()
        {
            Log.Info("Init objects");

            // Parent.Change("Ready");
        }

        
        
    }
}