using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static TimerTime bestTime;

    public float currentTime;
    public TextMeshProUGUI timeText; 

    public void ShowTime()
    {
        TimerTime myTime = FloatToTime(currentTime);

        timeText.text = string.Format("{0:00}:{1:00}", myTime.minutes, myTime.seconds);
    }

    public void Update()
    {
        currentTime += Time.deltaTime;
        ShowTime();
    }

    public TimerTime FloatToTime(float time)
    {
        TimerTime myTime = new TimerTime();
        myTime.minutes = Mathf.FloorToInt(time / 60f);
        myTime.seconds = Mathf.FloorToInt(time - (myTime.minutes * 60));
        return myTime;
    }


    public float TimeToFloat(TimerTime time)
    {
        return (time.minutes * 60) + time.seconds;
    }

}

public class TimerTime
{
    public int minutes;
    public int seconds;
}
