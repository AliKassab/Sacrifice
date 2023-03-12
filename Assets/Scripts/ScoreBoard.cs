using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoretext;

    private void Start()
    {
        scoretext= GetComponent<TMP_Text>();
        scoretext.text = "Score: 0";
    }

    public void increaseScore(int incAmount)
    {
        score += incAmount;
        scoretext.text = "Score: " + score.ToString();
    }
}
