﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEffect : MonoBehaviour
{
    public string freezeTag = "PlayerEffect";


    public Animator animator;

    //public GameObject iceEffectPrefab;

    public List<MeshRenderer> renderers = new List<MeshRenderer>();
    public List<SkinnedMeshRenderer> skinnedRenderers = new List<SkinnedMeshRenderer>();
    public Material freezeMaterial;


    public bool freezed = false;


    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        renderers = new List<MeshRenderer>(GetComponentsInChildren<MeshRenderer>());
        skinnedRenderers = new List<SkinnedMeshRenderer>(GetComponentsInChildren<SkinnedMeshRenderer>());
        if (GetComponent<Rigidbody>())
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(freezeTag))
        {
            if (other.GetComponentInParent<Freezer>())
            {
                Freeze(other.GetComponentInParent<Freezer>().freezeTime);
            }

        }
    }


    void Freeze(float freezeTime)
    {
        if (freezed) return;

        freezed = true;
        animator.enabled = false;

        if (rb)
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }

        foreach (MeshRenderer renderer in renderers)
        {
            List<Material> materials = new List<Material>(renderer.materials);
            materials.Add(freezeMaterial);
            renderer.materials = materials.ToArray();
        }
        foreach (SkinnedMeshRenderer skinnedRenderer in skinnedRenderers)
        {
            List<Material> materials = new List<Material>(skinnedRenderer.materials);
            materials.Add(freezeMaterial);
            skinnedRenderer.materials = materials.ToArray();
        }


        StartCoroutine(FreezeDuration(freezeTime));

    }

    public void UnFreeze()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            List<Material> materials = new List<Material>(renderer.materials);
            Material m = materials.Find(x => x.name == freezeMaterial.name + " (Instance)");
            materials.Remove(m);
            renderer.materials = materials.ToArray();
        }
        foreach (SkinnedMeshRenderer skinnedRenderer in skinnedRenderers)
        {
            List<Material> materials = new List<Material>(skinnedRenderer.materials);
            Material m = materials.Find(x => x.name == freezeMaterial.name + " (Instance)");
            materials.Remove(m);
            skinnedRenderer.materials = materials.ToArray();
        }

        freezed = false;
        animator.enabled = true;
    }

    IEnumerator FreezeDuration(float t)
    {
        yield return new WaitForSeconds(t);

        UnFreeze();

    }


}
