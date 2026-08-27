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

    public void Initialize(ITaskChecker taskChecker, IPointChecker pointChecker)
    {
        _taskChecker = taskChecker;
      _pointChecker = pointChecker;

        if (_taskChecker != null)
        {
            _taskChecker.OnStepResult += OnStepResult;
        }
        if (_pointChecker != null) { _pointChecker.OnCorrectPos += FirstColorText; Debug.Log("FirstColorText подписан"); }

    }

    private void OnDestroy()
    {
        if (_taskChecker != null)
        {
            _taskChecker.OnStepResult -= OnStepResult;
        }
        if (_pointChecker != null) { _pointChecker.OnCorrectPos -= FirstColorText; }
        //if (_pointChecker != null) { _pointChecker.OnCorrectPos -= FirstColorText; }
    }

    private void OnStepResult(int taskNumber, bool result)
    {
        if (taskNumber == 2)
        {
            if (result == true)
            {
                SecondTaskCorrect();
            }
            else
            {
                SecondTaskIncorrect();
            }
        }
        else if (taskNumber == 3)
        {
            if (result == true)
            {
                ThirdTaskCorrect();
            }
            else
            {
                ThirdTaskIncorrect();
            }
        }
    }

    private void FirstColorText()
    {
        Debug.Log("FirstColorText ВЫЗВАН!");
        _tasks[0].color = Color.green; 
        Debug.Log("TaskPanel: точка достигнута, первый таск выполнен");
    }

    private void SecondTaskCorrect()
    {
        _tasks[1].color = Color.green;

        Debug.Log("TaskPanel: вторая задача выполнена");
    }

    private void SecondTaskIncorrect()
    {
        _tasks[1].color = Color.red;

        Debug.Log("TaskPanel: вторая задача провалена");
    }

    private void ThirdTaskCorrect()
    {
        _tasks[2].color = Color.green;

        Debug.Log("TaskPanel: третья задача выполнена");
    }

    private void ThirdTaskIncorrect()
    {
        _tasks[2].color = Color.red;

        Debug.Log("TaskPanel: третья задача провалена");
    }
}