using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    int score = 0;

    // Materialを入れる
    Material myMaterial;

    //表示するテキスト
    private GameObject ScoreShowingText;

    // Use this for initialization
    void Start()
    {
        //シーン中のTextオブジェクトを取得
        this.ScoreShowingText = GameObject.Find("ScoreShowingText");

        score = 0;
        SetScore();   //初期スコアを代入して表示
    }

    void OnCollisionEnter(Collision collision)
    {

        //タグによってスコアを変える
        if (collision.gameObject.tag == "SmallStarTag")
        {
            score += 5;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            score += 10;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            score += 15;
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            score += 20;
        }

        SetScore();
    }

    void SetScore()
    { 
        //スコアを表示
        this.ScoreShowingText.GetComponent<Text>().text = string.Format("SCORE:{0}", score);
    }
    // Update is called once per frame
    void Update()
    {
    }
}