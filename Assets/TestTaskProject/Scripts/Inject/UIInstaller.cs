using UnityEngine;



/// <summary> 
/// Связывает UI с игровыми системами через интерфейсы
/// 
/// /// Выступает точкой настройки зависимостей между компонентами.
/// </summary>

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
        var conclusion = _levelConclusion as ILevelConclusion;

        if (conclusion == null)
        {
            Debug.LogError(
                $"{_levelConclusion.name} должен реализовывать ILevelConclusion"
            );

            return;
        }

        InstallWinPanel(conclusion);
        InstallTaskPanel(conclusion);
    }

    private void InstallWinPanel(ILevelConclusion conclusion)
    {
        _winPanel.Initialize(conclusion);
    }

    private void InstallTaskPanel(ILevelConclusion conclusion)
    {
        var taskChecker = _taskChecker as ITaskChecker;

        if (taskChecker == null)
        {
            Debug.LogError(
                $"{_taskChecker.name} должен реализовывать ITaskChecker"
            );

            return;
        }

        _taskPanel.Initialize(
            taskChecker,
            _pointChecker,
            conclusion
        );
    }
}