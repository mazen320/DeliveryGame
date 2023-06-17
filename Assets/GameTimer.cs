using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float currentTime = 90;
    [SerializeField] TextMeshProUGUI timerText;
    GameObject CountdownTimer;

    //Update is called once per frame
    private void Start()
    {
        CountdownTimer = GameObject.Find("CountdownTimer");
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0;
        }

        if (CountdownTimer.activeSelf == false)
        {
            TimeUI(currentTime);
        }



    }

    //if (currentTime == 0)
    //{
    //    SceneManager.LoadScene("UI.WinScreenProp");
    //}


    void TimeUI(float displayingTime)
    {
        if (displayingTime < 0)
        {
            displayingTime = 0;
        }

        float minutes = Mathf.FloorToInt(displayingTime / 60);
        float seconds = Mathf.FloorToInt(displayingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

}

