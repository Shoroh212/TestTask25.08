using TMPro;
using UnityEngine;

public class TaskPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _tasks;

    [SerializeField] private string[] _messages;

    private ITaskChecker _taskChecker;
    private IPointChecker _pointChecker;

    private void Start()
    {


     
        for (int i = 0; i < _tasks.Length; i++)
        {
            _tasks[i].text = _messages[i];
        }
    }

    public void Initialize(ITaskChecker pointChecker)
    {
        _taskChecker = pointChecker;

        _taskChecker.OnStepResult += HandleStepResult;
    }

    private void OnDestroy()
    {
        if (_taskChecker != null)
        {
            _taskChecker.OnStepResult -= HandleStepResult;
        }
    }


    private void FirstColorText() // вот этот метод должен выполнится если мы дошли до точки 
    {
        _tasks[0].color = Color.green;
    }

    private void HandleStepResult(int stepIndex, bool isCorrect)
    {
        if (stepIndex < 0 || stepIndex >= _tasks.Length)
        {
            Debug.LogWarning(
                $"TaskPanel: получен неизвестный индекс шага {stepIndex}"
            );

            return;
        }

        _tasks[stepIndex].color = isCorrect
            ? Color.green
            : Color.red;
    }
}