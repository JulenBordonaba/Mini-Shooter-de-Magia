using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public AudioSource fireSound;

    public ParticleSystem shotParticle;

    public Animator animator;

    public string fireInput = "Fire1";

    public float fireRate = 0.1f;

    [Header("CAMERA")]
    public Camera mainCamera;

    private bool canShot = true;
    private Vector3 playerToMouse;
    

    void Update()
    {
        

        if (PlayerManager.instance.Freezed) return;
        if (PauseManager.inPause) return;

        if (Input.GetButton(fireInput) && canShot)
        {
            animator.SetTrigger("Shot");
            StartCoroutine(ResetTriggerOnNextFrame());
            //Shoot();
        }
    }

    IEnumerator ResetTriggerOnNextFrame()
    {
        yield return new WaitForEndOfFrame();
        animator.ResetTrigger("Shot");
    }

    public void Shoot()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        //bool isTargeteable = false;


        Vector3 mouseWorldPosition = ScreenPointToWorldPointOnPlane(mouseScreenPosition, new Plane(Vector3.up, Vector3.zero), mainCamera);

        mouseWorldPosition.y = transform.position.y;

        playerToMouse = mouseWorldPosition - transform.position;

        //playerToMouse = agent.steeringTarget - transform.position;

        //playerToMouse.y = transform.position.y;
        playerToMouse.Normalize();

        Quaternion rot = Quaternion.LookRotation(playerToMouse);

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, rot);

        

        if (PlayerManager.instance.boosted)
        {
            bullet.GetComponent<Bullet>().boosted = true;
        }

        shotParticle?.Play();

        fireSound?.Play();

        canShot = false;
        StartCoroutine(ShotCooldown());
    }

    IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        canShot = true;
    }


    Vector3 ScreenPointToWorldPointOnPlane(Vector3 screenPoint, Plane plane, Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(screenPoint);
        
        float rayDistance = 0;
        plane.Raycast(ray, out rayDistance);
        return ray.GetPoint(rayDistance);

    }

    void DrawPlane(Vector3 position,  Vector3 normal)
    {

        Vector3 v3 ;

        if (normal.normalized != Vector3.forward)
            v3 = Vector3.Cross(normal, Vector3.forward).normalized * normal.magnitude;
        else
            v3 = Vector3.Cross(normal, Vector3.up).normalized * normal.magnitude; ;

        var corner0 = position + v3;
        var corner2 = position - v3;
        var q = Quaternion.AngleAxis(90.0f, normal);
        v3 = q * v3;
        var corner1 = position + v3;
        var corner3 = position - v3;

        Debug.DrawLine(corner0, corner2, Color.green);
        Debug.DrawLine(corner1, corner3, Color.green);
        Debug.DrawLine(corner0, corner1, Color.green);
        Debug.DrawLine(corner1, corner2, Color.green);
        Debug.DrawLine(corner2, corner3, Color.green);
        Debug.DrawLine(corner3, corner0, Color.green);
        Debug.DrawRay(position, normal, Color.red);
    }

}
