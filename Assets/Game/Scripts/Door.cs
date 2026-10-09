using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject doorModel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            doorModel.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            doorModel.SetActive(true);
    }
}
