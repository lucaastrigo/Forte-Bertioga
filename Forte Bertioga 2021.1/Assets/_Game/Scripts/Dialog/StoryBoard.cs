using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StoryBoard : MonoBehaviour
{
    public Sprite[] story;
    private int num;
    Image placeImage;

    void Start()
    {
        placeImage = GetComponentInChildren<Image>();
        placeImage.sprite = story[num];
    }

    void Update()
    {
        
    }

    public void NextItem()
    {
        if(num < story.Length - 1)
        {
            num++;
            placeImage.sprite = story[num];
        }
        else
        {
            SceneManager.LoadScene(SceneManager.sceneCount + 1);
        }
    }
}
