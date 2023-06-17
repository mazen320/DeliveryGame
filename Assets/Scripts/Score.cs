using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public int increaseAmount;

    public TextMeshProUGUI scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        increaseAmount = 5;
        scoreUI = GameObject.Find("ScoreUI").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: " + score.ToString();    
    }
    public void IncreaseScore()
    {
        score += increaseAmount;
        Debug.Log("score increased!");
    }
}
