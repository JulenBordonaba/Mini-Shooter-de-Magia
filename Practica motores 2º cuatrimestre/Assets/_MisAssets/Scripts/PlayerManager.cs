using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : Entity
{
    public static PlayerManager instance;

    public Rigidbody rb;

    public Animator scenaryAnimator;

    public bool boosted = false;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }

    public override void Kill()
    {
        base.Kill();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Booster"))
        {
            boosted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            boosted = false;
        }
    }

    public bool Freezed
    {
        get { return freezeEffect.freezed; }
    }
}
