using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour {

    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse rotateToMouse;
    public float cooldown;
    private float currentCooldown;

    private GameObject effectToSpawn;

    private void Start()
    {
        effectToSpawn = vfx[0];
        currentCooldown = cooldown;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && currentCooldown <= 0)
        {
            SpawnVFX();
            currentCooldown = cooldown;
        }
        currentCooldown -= Time.deltaTime;
    }

    private void SpawnVFX()
    {
        GameObject Vfx;
        if(firePoint)
        {
            Vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if(rotateToMouse)
            {
                Vfx.transform.localRotation = rotateToMouse.getRotation();
            }
        }
    }
}
