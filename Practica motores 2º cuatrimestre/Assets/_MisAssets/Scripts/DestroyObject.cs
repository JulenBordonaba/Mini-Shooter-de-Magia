using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public void DestroyOtherObject(GameObject objectToDestroy)
    {
        StartCoroutine(DestroyOnEndOfFrame(objectToDestroy));
    }

    public void DestroyThisObject()
    {
        StartCoroutine(DestroyOnEndOfFrame(gameObject));
    }

    IEnumerator DestroyOnEndOfFrame(GameObject objectToDestroy)
    {
        yield return new WaitForEndOfFrame();
        Destroy(objectToDestroy);
    }
}
