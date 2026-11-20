namespace Game.Scripts.States
{
    // Always needs access to a GameContext
    // to manipulate the scene
    public class BaseGameState : IState
    {
        protected readonly GameContext Context;

        // Creates an instance of this class with access to the
        // GameManager's context
        public BaseGameState(GameContext context)
        {
            Context = context;
        }

        // A virtual function is one that can be
        // overridden by its children
        public virtual void Enter() { /* NOOP */ }

        public virtual void Update() { /* NOOP */ }

        public virtual void Exit() { /* NOOP */ }
        
        // NOOP -> No Operation
    }
}