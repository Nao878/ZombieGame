using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    float speed = 0.001f;
    float red,green,blue,alfa;

    //public bool Out = false;
    public bool In = false;

    Image fadeImage;
    Sprite sprite;
    public string resultButtonPic,resultButtonPictime;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        alfa = 0;
    }

    void Update()
    {
        if (In)
        {
            FadeIn();
        }

        if (CharaController.fadeCheck)
        {
            FadeOut();

            if (CharaController.zombieCheck)
            {
                sprite = Resources.Load<Sprite>(resultButtonPic);
                fadeImage.sprite = sprite;
            }

            if (TitleController.timeOver)
            {
                sprite = Resources.Load<Sprite>(resultButtonPictime);
                fadeImage.sprite = sprite;
            }
        }
    }

    void FadeIn()
    {
        alfa -= speed;
        Alpha();
        if (alfa <= 0)
        {
            In = false;
            fadeImage.enabled = false;
        }
    }

    void FadeOut()
    {
        fadeImage.enabled = true;
        alfa += speed;
        Alpha();
        if (alfa >= 1)
        {
            CharaController.fadeCheck = false;
        }
    }

    void Alpha()
    {
        fadeImage.color = new Color(red,green,blue,alfa);
    }
}
