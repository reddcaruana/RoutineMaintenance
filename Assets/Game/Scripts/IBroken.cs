using System;

namespace Game.Scripts
{
    public interface IBroken
    {
        event Action Broken;
        event Action Repaired;
        
        /// <summary>
        /// Read-Only value flagging the object state.
        /// </summary>
        bool IsBroken { get; }
        
        void Fix();
    }
}