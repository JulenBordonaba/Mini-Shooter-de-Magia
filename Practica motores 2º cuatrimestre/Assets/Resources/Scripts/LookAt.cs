using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum Target
{
    ObjecTarget, MainCamera, EditorCamera
}

public class LookAt : MonoBehaviour
{
    public Target targetMode = Target.MainCamera;
    public GameObject target;
    public Vector3 lookVector;
    public bool plane = true;
    [Header("freeze")]
    public bool x;
    public bool y;
    public static Camera myCam;

    private Vector3 angles, angles2, dif, final;

    private void Start()
    {
        angles = transform.localEulerAngles;
    }

    private void Update()
    {
        if(targetMode==Target.ObjecTarget)
        {
            transform.LookAt(target.transform.position, lookVector);
        }
        else if(targetMode==Target.MainCamera)
        {
            transform.LookAt(myCam.transform.position, lookVector);
        }
        else if (targetMode == Target.EditorCamera)
        {
            transform.LookAt(myCam.transform.position, lookVector);
        }

        angles2 = transform.localEulerAngles;
        transform.localRotation = Quaternion.Euler(angles);
        dif = angles2 - angles;
        final = dif;
        if (x)
        {
            final.x = angles.x;
        }
        if (y)
        {
            final.y = angles.y;
        }
        final.z = angles.z;
        
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        this.transform.Rotate(final, Space.Self);
        if (plane)
        {
            if (!x && y)
            {
                transform.Rotate(0, 90, 0, Space.Self);
            }
            if (!y)
            {
                transform.Rotate(90, 0, 0, Space.Self);
            }
        }


    }
}


