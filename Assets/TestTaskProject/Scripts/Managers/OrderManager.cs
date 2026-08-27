using System;
using UnityEngine;

public class OrderManager : MonoBehaviour, ITaskChecker

{
    [Header("Expected order")]
    [SerializeField]
    private string[] _requiredTags =
    {
        "Step1",
        "Step2"
    };

    private int _currentStep;

    public event Action<int, bool> OnStepResult;

    public bool IsCompleted => _currentStep >= _requiredTags.Length;

    public bool CheckObject(string objectTag)
    {
        if (IsCompleted)
            return false;

        string expectedTag = _requiredTags[_currentStep];

        if (objectTag == expectedTag)
        {
            OnStepResult?.Invoke(_currentStep, true);

            _currentStep++;

            return true;
        }

        OnStepResult?.Invoke(_currentStep, false);

        // Все следующие шаги тоже считаем проваленными
        for (int i = _currentStep + 1; i < _requiredTags.Length; i++)
        {
            OnStepResult?.Invoke(i, false);
        }

        _currentStep = _requiredTags.Length;

        return false;
    }

    public void ResetOrder()
    {
        _currentStep = 0;
    }
}
public interface ITaskChecker
{
    event Action<int, bool> OnStepResult;
}