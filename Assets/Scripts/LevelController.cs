using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public Scene currScene;

    // Start is called before the first frame update
    void Start()
    {
        currScene = SceneManager.GetActiveScene();
        Debug.Log("Scene count: " + SceneManager.sceneCountInBuildSettings);
    }

    public void NextScene()
    {
        Debug.Log("started loading next scene");
        bool loadNext = false;
        for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            if (loadNext)
            {
                Debug.Log("should load scene " + i);
                SceneManager.LoadScene(i);
                return;
            }

            if(SceneManager.GetSceneByBuildIndex(i) == currScene)
            {
                loadNext = true;
            }
        }
        Debug.Log("failed to load");
    }

    public void ReloadScene()
    {
        Debug.Log("should reload");
        SceneManager.LoadScene(currScene.name);
    }

    public void LoadSpecificScene(int SceneBuildIndex){
        SceneManager.LoadScene(SceneBuildIndex);
    }
}
