using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary> /// Определяет завершение уровня и запускает переход на следующую сцену. /// </summary>
public class ConclusionLVL : MonoBehaviour, ILevelConclusion
{
  public event Action Finished;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ball") || other.CompareTag("LastCube"))
        {
            Finished?.Invoke();
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()  // Задержка через корутины, но через UniTask было бы лучшее 
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}



public interface ILevelConclusion
{
    event Action Finished;
}