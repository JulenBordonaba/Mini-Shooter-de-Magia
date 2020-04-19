using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float v = 0;
    private float horizontal = 0;
    private float vertical = 0;
    private Vector3 movimiento;
    private bool saltable = false;
    public Rigidbody rb;

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movimiento = new Vector3(0, 0, 0);
        movimiento += transform.forward * vertical;
        movimiento += transform.right * horizontal;
        movimiento = movimiento.normalized;
        movimiento = movimiento * v * GetComponent<Rigidbody>().mass;
        movimiento += new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
        GetComponent<Rigidbody>().velocity = movimiento;
    }

}
