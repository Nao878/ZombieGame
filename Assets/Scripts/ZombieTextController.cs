using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieTextController : MonoBehaviour
{
    TextMeshProUGUI charaText;
    string[] text = {
        "彼女はとてもホットです",
        "それを取得することは困難を与えます",
        "高いスコアを記録した",
        "かっこいいです。兄弟",
        "私は貴方のことが素晴らしいと思います",
        "それはとてもすばらしいです",
        "私も危ないことです",
        "Cute",
        "それはとても危ないと思います",
        "彼は強大な力を取得しました",
        "ジンギスカンはとても良いです",
        "悲しみが彼をそうさせた",
        "素晴らしいニュース",
        "これは素晴らしいことです",
        "それは水の海のチーム",
        "私は彼女にもそうさせたいと思います",
        "きちんとしたきれいなラインとシャープな色はとても美しいです",
        "Googleはまれに我々に困難を与えます",
        "人生は美しいので気を付けてください",
        "私はあなたが美しいと思います",
        "買収することを提案します",
        "運動は我々に健康を取得させる"
    };
    private int textNum = 0;
    private float delta = 0;

    void Start()
    {
        charaText = GetComponent<TextMeshProUGUI>();
        charaText.text = "";
    }

    void Update()
    {
        delta += Time.deltaTime;

        if (delta >= 4.5f)
        {
            delta = 0;
            textNum = Random.Range(0, text.Length);
            charaText.text = text[textNum];
        }
    }
}
