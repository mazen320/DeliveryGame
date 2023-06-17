using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 4f;

    public TextMeshProUGUI CountDownText;
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            print(currentTime);
            CountDownText.text = currentTime.ToString("0");
            CountDownText.color = Color.yellow;
        }
        if(currentTime < 0)
        {
            gameObject.SetActive(false);
        }
    

    }
}
