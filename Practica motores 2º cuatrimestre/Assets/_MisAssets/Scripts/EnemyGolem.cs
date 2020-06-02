using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGolem : Enemy
{
    public float shotCooldown = 2f;

    public float shotVelocity = 10f;

    public float stopDistance = 8f;

    public GameObject projectilePrefab;

    public Transform projecttileSpawn;

    public NavMeshAgent agent;

    public Animator animator;

    bool canShot = true;

    public bool active = false;

    private float agentVelocity;

    public override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agentVelocity = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;
        agent.SetDestination(PlayerManager.instance.transform.position);

        if (ObjectiveDistance < stopDistance+2 && !freezeEffect.freezed)
        {
            if (canShot)
            {
                Shot();
            }
        }

        if(freezeEffect.freezed)
        {
            agent.speed = 0f;
        }
        else if (ObjectiveDistance< stopDistance)
        {
            agent.speed = 0.7f;
        }
        else
        {
            agent.speed = agentVelocity;
        }
    }

    public void Shot()
    {
        canShot = false;
        GameObject projectile = Instantiate(projectilePrefab, projecttileSpawn.position, Quaternion.identity);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        projectileRb.velocity = (PlayerManager.instance.transform.position - projecttileSpawn.position + Vector3.up*1.5f).normalized*shotVelocity;

        projectileRb.angularVelocity = new Vector3(projectileRb.velocity.z, projectileRb.velocity.y, -projectileRb.velocity.x).normalized * 10f;

        Destroy(projectile, 6f);

        StartCoroutine(Recharge(shotCooldown));
    }

    IEnumerator Recharge(float t)
    {
        yield return new WaitForSeconds(t);
        canShot = true;
    }

    public float ObjectiveDistance
    {
        get { return Vector3.Distance(transform.position, PlayerManager.instance.transform.position); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            active = true;
        }
    }


}
