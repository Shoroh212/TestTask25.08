using UnityEngine;

public class UIInstaller : MonoBehaviour
{
    [Header("Win Panel")]
    [SerializeField] private MonoBehaviour _levelConclusion;
    [SerializeField] private WinPanel _winPanel;

    [Header("Task Panel")]
    [SerializeField] private MonoBehaviour _taskChecker;
    [SerializeField] private TaskPanel _taskPanel;
    [SerializeField] private PointChecker _pointChecker;

    private void Awake()
    {
        InstallWinPanel();
        InstallTaskPanel();
    }

    private void InstallWinPanel()
    {
        var conclusion = _levelConclusion as ILevelConclusion;

        if (conclusion == null)
        {
            Debug.LogError(
                $"{_levelConclusion.name} должен реализовывать ILevelConclusion"
            );

            return;
        }

        _winPanel.Initialize(conclusion);
    }

    private void InstallTaskPanel()
    {
        var taskChecker = _taskChecker as ITaskChecker;

        if (taskChecker == null)
        {
            Debug.LogError(
                $"{_taskChecker.name} должен реализовывать ITaskChecker"
            );

            return;
        }

        _taskPanel.Initialize(taskChecker, _pointChecker);
    }
}
