using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalDrop : MonoBehaviour
{
    public void RoomClear(string boolName)
    {
        PlayerManager.instance.scenaryAnimator.SetBool(boolName, true);
    }
}
