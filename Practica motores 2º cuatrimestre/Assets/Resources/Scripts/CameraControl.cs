using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -10.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt,personaje;
    public float distance;

    private float currentX = 0.0f;
    private float currentY = 45.0f;
    public float senX = 4.0f;
    public float senY = 1.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * senX;
        currentY -= Input.GetAxis("Mouse Y") * senY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        float lookAtY = (-(currentY - 20) / 10) + 5;
        lookAtY = Mathf.Clamp(lookAtY, 2, 8);

        lookAt.position = new Vector3(lookAt.position.x, lookAtY, lookAt.position.z);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * dir;
        transform.LookAt(lookAt.position);
        //personaje.rotation = Quaternion.Euler(0, currentX, 0);
    }
}
