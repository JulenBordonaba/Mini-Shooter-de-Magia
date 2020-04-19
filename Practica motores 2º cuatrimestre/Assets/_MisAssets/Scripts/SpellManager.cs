using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    public List<Spell> spells = new List<Spell>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Spell spell in spells)
        {
            if(Input.GetKeyDown(spell.useKey))
            {
                spell.Cast();
            }
        }
    }
}
