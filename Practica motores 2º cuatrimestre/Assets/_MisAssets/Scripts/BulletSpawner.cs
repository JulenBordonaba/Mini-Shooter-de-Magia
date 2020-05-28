using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public AudioSource fireSound;

    public ParticleSystem shotParticle;

    public string fireInput = "Fire1";

    public float fireRate = 0.1f;

    private bool canShot = true;

    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }

    void Update()
    {
        if(playerManager)
        {
            if (playerManager.Freezed) return;
        }
        if(Input.GetButton(fireInput) && canShot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        
        if(playerManager.boosted)
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
}
