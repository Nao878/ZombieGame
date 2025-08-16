using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleController : MonoBehaviour
{
    [SerializeField] private AudioSource a;
    [SerializeField] private AudioClip b;
    public GameObject title,startButton,CharaPrefab,zombiePrefab,canvas,countObject,countLastObj;
    public static bool sePlay,countCheck,timeOver = false;
    private bool charaGenerate,audioOneShot = false;
    public static float delta,count = 0;
    private int charaCount = 0;
    public TextMeshProUGUI countDownText;

    public void StartClick()
    {
        title.SetActive(false);
        startButton.SetActive(false);
        a.Stop();
        charaGenerate = true;
        countObject.SetActive(true);
        countCheck = true;
        CharaController.gameStart = true;
    }

    public void AudioClick()
    {
        a.Play();
    }

    public void Retry()
    {
        SceneManager.LoadScene("TitleScene");
        CharaController.clickCheck = false;
        CharaController.fadeCheck = false;
        CharaController.zombieCheck = false;
        timeOver = false;
    }

    void Update()
    {
        if (sePlay)
        {
            a.PlayOneShot(b);
            sePlay = false;
        }

        if (charaGenerate)
        {
            delta += Time.deltaTime;

            if (delta >= 1)
            {
                delta = 0;
                GameObject go = Instantiate(CharaPrefab);
                int px = Random.Range(-400, 400);
                int py = Random.Range(-250, 250);
                go.transform.position = new Vector3(px, py, 0);
                go.transform.SetParent(canvas.transform, false);
                charaCount++;
            }

            if (charaCount >= 10)
            {
                charaGenerate = false;
                GameObject go = Instantiate(zombiePrefab);
                int px = Random.Range(-400, 400);
                int py = Random.Range(-250, 250);
                go.transform.position = new Vector3(px, py, 0);
                go.transform.SetParent(canvas.transform, false);
            }
        }

        if (CharaController.clickCheck && !audioOneShot)
        {
            a.Play();
            audioOneShot = true;
        }

        if (countCheck)
        {
            count += Time.deltaTime;
            countDownText.text = count.ToString("F0");

            if (count >= 30)
            {
                timeOver = true;
                CharaController.clickCheck = true;
                CharaController.fadeCheck = true;
                //countObject = GameObject.Find("CountDownText");
                countObject.SetActive(false);
                countCheck = false;
                count = 0;
                CharaController.gameStart = false;
            }
        }

        if (CharaController.zombieCheck)
        {
            countLastObj.SetActive(true);
        }
    }
}
