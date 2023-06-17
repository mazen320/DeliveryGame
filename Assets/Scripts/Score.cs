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

        scoreUI = GameObject.Find("ScoreUI").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = score.ToString();    
    }
    public void IncreaseScore()
    {
        score += increaseAmount;
        Debug.Log("score increased!");
    }
}
