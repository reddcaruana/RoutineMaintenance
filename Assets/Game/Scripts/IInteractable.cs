namespace Game.Scripts
{
    public interface IInteractable
    {
        // Doesn't care what kind of inventory it's using
        // as long as the contract is respected
        void Interact();
    }
}