using System;
using UnityEngine;

public class OrderManager : MonoBehaviour, IOrderChecker
{
    [Header("Expected order")]
    [SerializeField]
    private string[] _requiredTags =
    {
        "Step1",
        "Step2"
    };

    private int _currentStep;

    public bool IsCompleted => _currentStep >= _requiredTags.Length;

    public event Action OnCorrectAction;
    public event Action OnWrongAction;

    public bool CheckObject(string objectTag)
    {
        if (IsCompleted)
            return false;

        string expectedTag = _requiredTags[_currentStep];

        if (objectTag == expectedTag)
        {
            HandleCorrectAction();
            return true;
        }

        HandleWrongAction();
        return false;
    }

    private void HandleCorrectAction()
    {
        OnCorrectAction?.Invoke();

        _currentStep++;

        if (IsCompleted)
        {
            Debug.Log("Все действия выполнены правильно.");
        }
    }

    private void HandleWrongAction()
    {
        OnWrongAction?.Invoke();

        Debug.LogWarning(
            $"Нарушение порядка. " +
            $"Ожидался тег: {_requiredTags[_currentStep]}"
        );
    }

    public void ResetOrder()
    {
        _currentStep = 0;
    }
}