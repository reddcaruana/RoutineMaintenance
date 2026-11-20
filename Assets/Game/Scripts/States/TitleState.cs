using UnityEngine;

namespace Game.Scripts.States
{
    public class TitleState : BaseGameState
    {
        // Replaces the BaseGameState version
        public TitleState(GameContext context) : base(context)
        { /* NOOP */ }

        public override void Enter()
        {
            Context.TitleScreen.Show();
        }
        
        // Replaces the BaseGameState version
        public override void Exit()
        {
            Context.TitleScreen.Hide();
        }
    }
}