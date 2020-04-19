using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public bool local = false;
    public Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        if (local)
        {
            transform.Rotate(rotation * Time.deltaTime,Space.Self);
        }
        else
        {
            transform.Rotate(rotation*Time.deltaTime,Space.World);
        }
    }
}
