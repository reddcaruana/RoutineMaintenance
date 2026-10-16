using UnityEngine;

namespace Game.Scripts
{
    public class Computer : MonoBehaviour
    {
        [SerializeField] private Door door;

        public void Use()
        {
            door.Open();
        }
    }
}