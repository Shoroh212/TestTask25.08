using UnityEngine;

public class UIInstaller : MonoBehaviour
{
    [Header("Win Panel")]
    [SerializeField] private MonoBehaviour _levelConclusion;
    [SerializeField] private WinPanel _winPanel;

    [Header("Task Panel")]
    [SerializeField] private MonoBehaviour _pointChecker;
    [SerializeField] private TaskPanel _taskPanel;

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
        var pointChecker = _pointChecker as IPointChecker;

        if (pointChecker == null)
        {
            Debug.LogError(
                $"{_pointChecker.name} должен реализовывать IPointChecker"
            );

            return;
        }

        _taskPanel.Initialize(pointChecker);
    }
}