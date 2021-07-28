using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
  public void LevelLoad(int SceneIndex)
  {
    StartCoroutine(LoadAsynchronously(SceneIndex));
  }
  IEnumerator LoadAsynchronously (int SceneIndex)
  {
     AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

     while(!operation.isDone)
     {
       float progress = Mathf.Clamp01(operation.progress / .9f);
       Debug.Log(progress);

       yield return null;
     }
  }
}
