using System;
using UnityEngine;

namespace Game.Scripts
{
    public class Display : MonoBehaviour
    {
        [SerializeField] private Computer computer;
        
        [SerializeField] private Material brokenMat;
        [SerializeField] private Material workingMat;

        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        // Subscribes to the computer's broken/repaired events
        private void OnEnable()
        {
            computer.Repaired += OnRepaired;
            computer.Broken += OnBroken;
        }

        // Unsubscribes from the computer's events
        private void OnDisable()
        {
            computer.Repaired -= OnRepaired;
            computer.Broken -= OnBroken;
        }

        private void OnRepaired() => SetWorking(true);

        private void OnBroken() => SetWorking(false);

        private void SetWorking(bool working)
        {
            // inline condition
            meshRenderer.material = working
                ? workingMat // working == true
                : brokenMat; // working == false
        }
    }
}