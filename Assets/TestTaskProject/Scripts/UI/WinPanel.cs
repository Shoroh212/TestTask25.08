using UnityEngine;

public class WinPanel : MonoBehaviour
{
    private ILevelConclusion _levelConclusion;

    public void Initialize(ILevelConclusion levelConclusion)
    {
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