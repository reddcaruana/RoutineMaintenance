namespace Game.Scripts.States
{
    // Concrete implementation of what a state machine is in the game
    public class StateMachine
    {
        // Read-Only property visible to other classes
        public IState CurrentState { get; private set; }

        // Stops a state and starts a new one
        public void ChangeState(IState state)
        {
            // Can't transition to the same state
            if (CurrentState == state)
                return;
            
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState?.Enter();
        }
        
        // Runs the update function
        public void Update()
        {
            // if not null, run update
            CurrentState?.Update();
        }
    }
}