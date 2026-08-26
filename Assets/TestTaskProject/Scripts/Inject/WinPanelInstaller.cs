using UnityEngine;

public class WinPanelInstaller : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _levelConclusion;

    [SerializeField] private WinPanel _winPanel;

    private void Awake()
    {
        var conclusion = _levelConclusion as ILevelConclusion;

        if (conclusion == null)
        {
            Debug.LogError($"{_levelConclusion.name} должен реализовывать ILevelConclusion");
            return;
        }

        _winPanel.Initialize(conclusion);
    }
}