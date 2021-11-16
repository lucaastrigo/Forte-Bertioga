using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorMain : MonoBehaviour
{
    public Image imagem;
    public Sprite[] sprites;

    public int num;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (num == 0) SkinsAnimator.player1 = true;
        else SkinsAnimator.player1 = false;
        if (num == 1) SkinsAnimator.player2 = true;
        else SkinsAnimator.player2 = false;
        if (num == 2) SkinsAnimator.player3 = true;
        else SkinsAnimator.player3 = false;

        if (num > 2)
        {
            num = 0;
            imagem.sprite = sprites[num];

        }
        else if(num < 0)
        {
            num = 2;
            imagem.sprite = sprites[num];

        }
    }

    public void Proximo()
    {
        num++;
        imagem.sprite = sprites[num];

    }

    public void Anterior()
    {
        num--;
        imagem.sprite = sprites[num];
    }
}
