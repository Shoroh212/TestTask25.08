using System;
using UnityEngine;

public class PointChecker : MonoBehaviour
{
    public event Action OnCorrectPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCorrectPos?.Invoke();
            Debug.Log("12342");
        }
    }
}
