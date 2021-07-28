using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{ 
    //public int loadLevel;
    //public string sloadLevel;

    //public bool useIntLoadLevel = false;
    
    // Try and figure out how to update scenes
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        GameObject collisionObject = collision.gameObject;

        //if(collision.gameObject.CompareTag("Player")==true)
        //{
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
        Debug.Log("OnTriggerEnter Called");
        //use for game overs
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*void LoadDaScene()
    {
      if(useIntLoadLevel == true)
      {
         SceneManager.LoadScene(loadLevel);
         Debug.Log("Scene Detected");
      }
      else
      {
        SceneManager.LoadScene(sloadLevel);
        Debug.Log("Scene Detected");
      }
    }*/
   
}
