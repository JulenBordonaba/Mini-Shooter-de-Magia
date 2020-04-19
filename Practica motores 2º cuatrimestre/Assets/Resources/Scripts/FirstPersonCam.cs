using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour {

    private const float Y_ANGLE_MIN = -10.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;
    public float senX = 4.0f;
    public float senY = 4.0f;

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * senX;
        currentY -= Input.GetAxis("Mouse Y") * senY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

}
