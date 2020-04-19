using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{


    private Camera myCam;

    private void Awake()
    {
        myCam = GetComponent<Camera>();
        LookAt.myCam = myCam;
        Camera.SetupCurrent(myCam);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
