using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour {

    public Camera cam;
    public float maxLenght;

    private Ray mouseRay;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    private void Update()
    {
        if(cam)
        {
            RaycastHit hit;
            Vector3 mousePos = Input.mousePosition;
            mouseRay = cam.ScreenPointToRay(mousePos);
            if(Physics.Raycast(mouseRay.origin,mouseRay.direction, out hit,maxLenght))
            {
                rotateToMouseDirection(gameObject, hit.point);
            }
            else
            {
                Vector3 pos = mouseRay.GetPoint(maxLenght);
                rotateToMouseDirection(gameObject, pos);
            }
        }
    }

    private void rotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    public Quaternion getRotation()
    {
        return rotation;
    }

}
