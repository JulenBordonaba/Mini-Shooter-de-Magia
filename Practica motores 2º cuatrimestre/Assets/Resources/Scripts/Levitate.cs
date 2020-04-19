using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour {

    public float speed,diferencia,momentoInicial;
    private float y = 0;

    private void Start()
    {
        y = momentoInicial;
        if (y > 360) y -= 360;
    }

    // Update is called once per frame
    void Update () {

        y += Time.deltaTime * speed;
        if (y >= 360) y -= 360;

        transform.Translate(new Vector3(0, Mathf.Sin(y) * diferencia, 0),Space.World);

	}
}
