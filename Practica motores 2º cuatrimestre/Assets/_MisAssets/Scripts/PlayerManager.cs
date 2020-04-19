using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool freezed = false;
    public bool boosted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Booster"))
        {
            boosted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            boosted = false;
        }
    }
}
