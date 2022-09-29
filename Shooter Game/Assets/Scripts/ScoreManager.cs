using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    Text scoreText;

    public Text hightScore;
    void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0;
        hightScore.text = PlayerPrefs.GetInt("hightScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("hightScore"))  // score
        {
            PlayerPrefs.SetInt("hightScore",score);
            
        }
       
    }
}
