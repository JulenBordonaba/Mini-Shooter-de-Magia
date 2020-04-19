using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public Camera cam;
    public GameObject firePoint;
    private LineRenderer lr;
    public float maxLenght;

    private void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lr.SetPosition(0, firePoint.transform.position);
        if (Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftAlt))
        {
            lr.enabled = true;
        }
        else
        {
            lr.enabled = false;
        }
            RaycastHit hit;
            Vector3 mousePos = Input.mousePosition;
            Ray mouseRay = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, maxLenght))
            {
                lr.SetPosition(1, hit.point);
            }
            else
            {
                Vector3 pos = mouseRay.GetPoint(maxLenght);
                lr.SetPosition(1, pos);
            }
        


    }


}
