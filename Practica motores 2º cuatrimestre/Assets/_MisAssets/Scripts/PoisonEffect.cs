using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEffect : MonoBehaviour
{
    public string poisonTag = "PlayerEffect";

    public Entity entity;
    

    //public GameObject iceEffectPrefab;

    public List<MeshRenderer> renderers = new List<MeshRenderer>();
    public List<SkinnedMeshRenderer> skinnedRenderers = new List<SkinnedMeshRenderer>();
    public Material poisonMaterial;

    public float poisonTime = 0;

    public Coroutine poisonCoroutine;

    public bool poisoned = false;

    public float poisonDamage;

    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<Entity>();
        renderers = new List<MeshRenderer>(GetComponentsInChildren<MeshRenderer>());
        skinnedRenderers = new List<SkinnedMeshRenderer>(GetComponentsInChildren<SkinnedMeshRenderer>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(poisonTag))
        {
            if (other.GetComponentInParent<Poisoner>())
            {
                Poisoner p = other.GetComponentInParent<Poisoner>();
                Poison(p.poisonTime);
                if (poisonDamage < p.damagePerSecond)
                {
                    poisonDamage = p.damagePerSecond;
                }
            }

        }
    }


    void Poison(float freezeTime)
    {
        

        poisonTime += freezeTime;

        //GameObject iceEffect=Instantiate(iceEffectPrefab, new Vector3(transform.position.x, 0.01f, transform.position.z), Quaternion.identity);
        if(poisonCoroutine==null)
        {

            poisoned = true;
            foreach (MeshRenderer renderer in renderers)
            {
                List<Material> materials = new List<Material>(renderer.materials);
                materials.Add(poisonMaterial);
                renderer.materials = materials.ToArray();
            }
            foreach (SkinnedMeshRenderer skinnedRenderer in skinnedRenderers)
            {
                List<Material> materials = new List<Material>(skinnedRenderer.materials);
                materials.Add(poisonMaterial);
                skinnedRenderer.materials = materials.ToArray();
            }
            poisonCoroutine = StartCoroutine(PoisonDuration());
        }
        
    }

    IEnumerator PoisonDuration()
    {
        while(poisonTime>0)
        {
            yield return new WaitForSeconds(1f);
            poisonTime -= 1;
            entity.TakeDamage(poisonDamage);
        }
        UnPoison();
    }


    void UnPoison()
    {
        StopCoroutine(poisonCoroutine);
        poisonCoroutine = null;
        poisoned = false;
        foreach (MeshRenderer renderer in renderers)
        {
            List<Material> materials = new List<Material>(renderer.materials);
            Material m = materials.Find(x => x.name == poisonMaterial.name + " (Instance)");
            materials.Remove(m);
            renderer.materials = materials.ToArray();
        }
        foreach (SkinnedMeshRenderer skinnedRenderer in skinnedRenderers)
        {
            List<Material> materials = new List<Material>(skinnedRenderer.materials);
            Material m = materials.Find(x => x.name == poisonMaterial.name + " (Instance)");
            materials.Remove(m);
            skinnedRenderer.materials = materials.ToArray();
        }

        //iceEffect.GetComponent<Animator>().SetTrigger("Disappear");

    }
}
