using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEffect : MonoBehaviour
{
    public string freezeTag = "Freeze";


    public Animator animator;

    public GameObject iceEffectPrefab;

    public List<MeshRenderer> renderers = new List<MeshRenderer>();
    public List<SkinnedMeshRenderer> skinnedRenderers = new List<SkinnedMeshRenderer>();
    public Material freezeMaterial;


    public bool freezed = false;

    // Start is called before the first frame update
    void Start()
    {
        renderers = new List<MeshRenderer>(GetComponentsInChildren<MeshRenderer>());
        skinnedRenderers = new List<SkinnedMeshRenderer>(GetComponentsInChildren<SkinnedMeshRenderer>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(freezeTag))
        {
            Freeze();
        }
    }


    void Freeze()
    {
        freezed = true;
        animator.enabled = false;
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

        //GameObject iceEffect=Instantiate(iceEffectPrefab, new Vector3(transform.position.x, 0.01f, transform.position.z), Quaternion.identity);

        StartCoroutine(UnFreeze(6f, null));
    }

    IEnumerator UnFreeze(float t, GameObject iceEffect)
    {
        yield return new WaitForSeconds(t);

        freezed = false;
        animator.enabled = true;
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

        //iceEffect.GetComponent<Animator>().SetTrigger("Disappear");

    }


}
