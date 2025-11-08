using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CharaController : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private float speed = 1;
    private int xDspeed,yDspeed,moveCount = 0;
    TextMeshProUGUI charaFace;
    public static bool clickCheck,fadeCheck,zombieCheck,gameStart = false;
    public GameObject countObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        TitleController.sePlay = true;
        xDspeed = Random.Range(-20, 20);
        yDspeed = Random.Range(-20, 20);
        charaFace = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        speed -= Time.deltaTime;

        if (speed <= -1)
        {
            speed = 1;
            moveCount++;
        }

        rb.linearVelocity = new Vector2(xDspeed, speed * 5 + yDspeed);

        if (moveCount >= 5)
        {
            xDspeed = Random.Range(-20, 20);
            yDspeed = Random.Range(-20, 20);
            moveCount = 0;
        }

        if (clickCheck)
        {
            xDspeed = 0;
            yDspeed = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hit");
        TitleController.sePlay = true;

        if (collision.gameObject.tag == "Player")
        {
            xDspeed = Random.Range(-10, 10);
            yDspeed = Random.Range(-10, 10);
        }

        if (collision.gameObject.tag == "WallAbove")
        {
            xDspeed = Random.Range(-10, 10);
            yDspeed = Random.Range(-10, -5);
        }

        if (collision.gameObject.tag == "WallUnder")
        {
            xDspeed = Random.Range(-10, 10);
            yDspeed = Random.Range(5, 10);
        }

        if (collision.gameObject.tag == "WallLeft")
        {
            xDspeed = Random.Range(5, 10);
            yDspeed = Random.Range(-10, 10);
        }

        if (collision.gameObject.tag == "WallRight")
        {
            xDspeed = Random.Range(-10, -5);
            yDspeed = Random.Range(-10, 10);
        }
    }

    public void OnPointerEnter()
    {
        if (!clickCheck)
        {
            charaFace.text = "(｀・ω・´)";
        }
    }

    public void OnPointerExit()
    {   
        if (!clickCheck)
        {
            charaFace.text = "(´・ω・｀)";
        }
    }

    public void OnPointerClick()
    {
        if (gameStart)
        {
            charaFace.text = "((; ﾟдﾟ  ))";
            clickCheck = true;
            fadeCheck = true;
            countObject = GameObject.Find("CountDownText");
            countObject.SetActive(false);
            TitleController.countCheck = false;
            TitleController.count = 0;
            gameStart = false;
        }
    }

    public void OnPointerClickZombie()
    {
        charaFace.text = "((; ﾟдﾟ  ))";
        clickCheck = true;
        fadeCheck = true;
        zombieCheck = true;
        countObject = GameObject.Find("CountDownText");
        countObject.SetActive(false);
        TitleController.countCheck = false;
        gameStart = false;
    }
}
