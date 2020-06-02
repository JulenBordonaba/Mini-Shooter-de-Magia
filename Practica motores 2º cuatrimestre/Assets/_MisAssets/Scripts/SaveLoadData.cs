using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadData : Singleton<SaveLoadData>
{


    private void Start()
    {
        try
        {
            Timer.bestTime = Global.LoadData<TimerTime>("BestTime.json");
        }
        catch
        {
            Timer.bestTime = null;
        }
    }

    private void OnApplicationQuit()
    {
        Timer.bestTime.SaveData<TimerTime>("BestTime.json");
    }
}
