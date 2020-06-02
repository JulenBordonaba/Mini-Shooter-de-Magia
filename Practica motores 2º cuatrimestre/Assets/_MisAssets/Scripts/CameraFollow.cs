using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float cameraDamping = 3f;

    private Vector3 diference;




    // Start is called before the first frame update
    void Start()
    {
        diference = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position-diference, Time.deltaTime * cameraDamping);
    }
}
