using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float currentTime = 90;
    public GameObject screenPopUp;
    public GameObject button;
    public GameObject waypoint;
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
            button.SetActive(false);
            screenPopUp.SetActive(false);

            waypoint.SetActive(true);
        }
        else
        {
            currentTime = 0;
            button.SetActive(true);
            screenPopUp.SetActive(true);

            waypoint.SetActive(false);
        }

        if (CountdownTimer.activeSelf == false)
        {
            TimeUI(currentTime);
        }



    }

   


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

