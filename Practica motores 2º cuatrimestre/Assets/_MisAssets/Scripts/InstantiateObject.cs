using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public GameObject objectToInstantiate;

    public void Instantiate()
    {
        Instantiate(objectToInstantiate, transform.position, transform.rotation);
    }
}
