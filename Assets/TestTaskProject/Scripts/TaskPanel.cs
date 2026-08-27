using TMPro;
using UnityEngine;

public class TaskPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _tasks;
    [SerializeField] private string[] _messages;

    private IPointChecker _pointChecker;

    private void Start()
    {
        _tasks[2].color = Color.red;
        for (int i = 0; i < _tasks.Length; i++)
        {
            _tasks[i].text = _messages[i];
        }
    }

    public void Initialize(IPointChecker pointChecker)
    {
        _pointChecker = pointChecker;

        if (_pointChecker != null)
        {
            _pointChecker.OnCorrectPos += FirstColorText;
        }
    }

    private void OnDestroy()
    {
        if (_pointChecker != null)
        {
            _pointChecker.OnCorrectPos -= FirstColorText;
        }
    }

    private void FirstColorText()
    {
        _tasks[0].color = Color.green;

        Debug.Log("TaskPanel: точка достигнута, первый таск выполнен");
    }
}
