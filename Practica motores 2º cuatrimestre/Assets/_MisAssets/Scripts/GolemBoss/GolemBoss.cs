using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GolemBoss : Enemy
{

    public GameObject fireProjectilePrefab;

    public Transform fireProjectileSpawn;

    public GameObject iceProjectilePrefab;

    public Transform iceProjectileSpawn;

    public GameObject chargeObject;

    public GameObject spinObject;

    public Timer timer;
    


    public float shotVelocity = 10;

    public float knockUpForce = 20f;
    

    public float sprintSpeed = 10f;

    public float spintSpeed = 7f;

    public override void Kill()
    {
        CheckTime();
        SceneManager.LoadScene("MainMenu");
        base.Kill();

    }


    public void CheckTime()
    {
        if (Timer.bestTime != null)
        {
            if (timer.currentTime < timer.TimeToFloat(Timer.bestTime))
            {
                Timer.bestTime = timer.FloatToTime(timer.currentTime);
            }
        }
        else
        {
            Timer.bestTime = timer.FloatToTime(timer.currentTime);
        }
    }


    public void ShotLeft()
    {
        GameObject projectile = Instantiate(fireProjectilePrefab, fireProjectileSpawn.position, Quaternion.identity);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        projectileRb.velocity = (PlayerManager.instance.transform.position - fireProjectileSpawn.position + Vector3.up * 1.5f).normalized * shotVelocity;

        projectileRb.angularVelocity = new Vector3(projectileRb.velocity.z, projectileRb.velocity.y, -projectileRb.velocity.x).normalized * 10f;

        Destroy(projectile, 6f);

    }

    public void SHotRight()
    {
        GameObject projectile = Instantiate(iceProjectilePrefab, iceProjectileSpawn.position, Quaternion.identity);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        projectileRb.velocity = (PlayerManager.instance.transform.position - iceProjectileSpawn.position + Vector3.up * 1.5f).normalized * shotVelocity;

        projectileRb.angularVelocity = new Vector3(projectileRb.velocity.z, projectileRb.velocity.y, -projectileRb.velocity.x).normalized * 10f;

        Destroy(projectile, 6f);

    }

    public void KnockUpPlayer()
    {
        if(PlayerManager.instance.freezeEffect.freezed)
        {
            PlayerManager.instance.freezeEffect.UnFreeze();
        }
        PlayerManager.instance.rb.AddForce(KnockUpDirection * knockUpForce, ForceMode.VelocityChange);
    }

    public Vector3 KnockUpDirection
    {
        get { return new Vector3(PlayerDirection.x, 0, PlayerDirection.z); }
    }

    public Vector3 PlayerDirection
    {
        get { return PlayerManager.instance.transform.position - iceProjectileSpawn.position; }
    }


}
