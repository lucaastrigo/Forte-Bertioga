using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MiniGameAccess : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        //
    }

    void Update()
    {
        //
    }

    public void AccessMinigame()
    {
        SceneManager.LoadScene(sceneName);

        print(sceneName + " scene is loaded");
    }
}
