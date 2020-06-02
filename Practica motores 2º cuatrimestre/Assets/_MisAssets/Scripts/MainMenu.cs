using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI recordText;

    private void Start()
    {
        ShowRecord();
    }
    
    public void ShowRecord()
    {
        if (Timer.bestTime == null)
        {
            recordText.text = "Record: --:--";
            return;
        }
        recordText.text = string.Format("Record: {0:00}:{1:00}", Timer.bestTime.minutes, Timer.bestTime.seconds);
    }
}
