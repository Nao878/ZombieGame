using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharaTextController : MonoBehaviour
{
    TextMeshProUGUI charaText;
    string[] text = {
        "のど湧いた",
        "眠い",
        "うぽつ",
        "今日の夕飯カレーだ",
        "俺イケメンすぎ",
        "彼女ほしい",
        "今日ついてないな",
        "水のように優しく～",
        "筋トレ明日からにしよ",
        "課題終忘れてた！",
        "筋肉だけが友達さ",
        "最近AIが刃向かってくる",
        "レッドカーペットは俺の為に作られたんやで",
        "バナナの皮って本当に滑るの？",
        "毎日がeveryday",
        "俺の人生は生まれたときから最高！だからニートの今も最高！",
        "ちょっと醤油が足りてないと思います",
        "食べログ見てたら一日が終わってた",
        "日本人は毎日寿司を食べてます",
        "俺が地球温暖化を止める",
        "実は俺プ〇キュアなんだよね",
        "挑戦しないということは、挑戦しないということです",
        "中国人はみんな少林寺拳法使えます",
        "俺のベイブ〇ードに勝てるかな",
        "薄毛になってきたので、お坊さんになろうと思います",
        "火属性の人は水飲めないの？",
        "なかとみのかまたり",
        "DX変身ベルトって変身機能ないんだ..",
        "最近毎回すり抜ける",
        "ダイエットは3日できればええんや",
        "レインボーブリッジ封鎖しました！",
        "レインボーブリッジ買収しました！",
        "御社の株を全部買わせていただきます",
        "テロリストが来た時の妄想するの楽しい",
        "ファル〇ンパンチ！",
        "追試が頭から離れない",
        "世界の真ん中で愛を叫ぶのが仕事です",
        "最近筋肉と喧嘩しちゃって..",
        "英語テスト4点でした、英語って必要あります？",
        "教えてクレメンスって何か教えてくれ",
        "バイトってどうやったら受かるん？"};
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
