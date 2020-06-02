using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpell : Spell
{
    public ParticleSystem spellEffect;
    public GameObject effectGuide;
    public Camera myCamera;

    bool casting = false;

    private Plane cameraPlane;

    // Start is called before the first frame update
    void Start()
    {
        cameraPlane = new Plane(transform.up, new Vector3(0f,0.01f,0f));
        effectGuide.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        if(casting)
        {
            effectGuide.transform.position= ScreenPointToWorldPointOnPlane(Input.mousePosition, cameraPlane, myCamera);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Use();
            }
            else if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                casting = false;
                effectGuide.SetActive(false);
            }
        }
    }

    public override void Cast()
    {
        base.Cast();
        if (inCooldown) return;
        casting = true;
        effectGuide.SetActive(true);
    }

    protected override void Use()
    {
        base.Use();

        inCooldown = true;
        animator.SetTrigger("Cast");
        StartCoroutine(Cooldown());
        casting = false;
        effectGuide.SetActive(false);

        Vector3 spawnPosition = ScreenPointToWorldPointOnPlane(Input.mousePosition, cameraPlane, myCamera);
        ParticleSystem effect=Instantiate(spellEffect, spawnPosition, spellEffect.transform.rotation);
        Destroy(effect.gameObject, effect.main.duration);
    }

    Vector3 ScreenPointToWorldPointOnPlane(Vector3 screenPoint, Plane plane, Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(screenPoint);

        float rayDistance = 0;
        plane.Raycast(ray, out rayDistance);
        return ray.GetPoint(rayDistance);
    }

}
