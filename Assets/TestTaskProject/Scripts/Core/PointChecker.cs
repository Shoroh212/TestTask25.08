using System;
using UnityEngine;


public class PointChecker : MonoBehaviour, IPointChecker
{
    public event Action OnCorrectPos;
    [SerializeField] private Outline _pointOutline;
    [SerializeField] private Outline _nextOutline;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCorrectPos?.Invoke();
            _pointOutline.enabled = false;
            _nextOutline.enabled = true;
            Debug.Log("12342");
           // Destroy(gameObject);
        }
    }
}
public interface IPointChecker
{
    event Action OnCorrectPos;
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