using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> /// Отвечает за запуск игры и переход на игровую сцену. /// </summary>
public class StrtGame : MonoBehaviour
{
   public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
