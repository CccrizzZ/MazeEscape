using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingScript : MonoBehaviour
{


    void Start()
    {
        // start loading game scene
        StartCoroutine(LoadGameScene());
    }
    void Update()
    {
        
    }
    
    
    IEnumerator LoadGameScene()
    {
        

        // start load game scene asynchronously
        AsyncOperation LoadAsync = SceneManager.LoadSceneAsync("GameScene");

        while (!LoadAsync.isDone)
        {
            yield return null;
        }
    }

}
