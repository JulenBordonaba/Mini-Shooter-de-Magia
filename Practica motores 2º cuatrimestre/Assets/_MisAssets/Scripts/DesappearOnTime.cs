using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesappearOnTime : MonoBehaviour
{
    public float waitTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }
    
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<Animator>().SetTrigger("Disappear");
    }

}
