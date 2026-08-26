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

public interface IObjectInteraction
{
    int ObjectId { get; }
    string ObjectTag { get; }

    event Action<int> ObjectTaken;
}
public interface IOrderChecker
{
    bool CheckObject(string objectTag);

    bool IsCompleted { get; }

    event Action OnCorrectAction;
    event Action OnWrongAction;

    void ResetOrder();
}