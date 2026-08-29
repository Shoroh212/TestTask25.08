using System;
using UnityEngine;

public class OrderManager : MonoBehaviour, ITaskChecker   // Проверяет правильность выполнения последовательности игровых заданий
{
    [Header("Expected order")]
    [SerializeField]
    private string[] _requiredTags =
    {
        "Step1",
        "Step2"
    };      //кол-во задач

    private int _currentStep;

    public event Action<int, bool> OnStepResult;

    public bool IsCompleted => _currentStep >= _requiredTags.Length;

    public bool CheckObject(string objectTag)
    {
        if (IsCompleted)
            return false;

        string expectedTag = _requiredTags[_currentStep];

        // Step1  задача 1
        // Step2  задача 2
        int taskNumber = _currentStep + 2;

        if (objectTag == expectedTag)
        {
            OnStepResult?.Invoke(taskNumber, true);

            _currentStep++;

            return true;
        }

        OnStepResult?.Invoke(taskNumber, false);

        // Все следующие шаги тоже считаем проваленными
        for (int i = _currentStep + 1; i < _requiredTags.Length; i++)
        {
            OnStepResult?.Invoke(i + 2, false);
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