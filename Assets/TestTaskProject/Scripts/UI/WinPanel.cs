using UnityEngine;

public class WinPanel : MonoBehaviour  // Показывает панель победы после завершения уровня
{
    private ILevelConclusion _levelConclusion;

    public void Initialize(ILevelConclusion levelConclusion)
    { // Подписываем UI на событие завершения уровня
        _levelConclusion = levelConclusion;
        _levelConclusion.Finished += ShowPanel;

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (_levelConclusion != null)
        {
            _levelConclusion.Finished -= ShowPanel;
        }
        else
        { Debug.Log("Нет LevelConclusion "); }
                

    }

    private void ShowPanel()
    {
        gameObject.SetActive(true);
    }
}