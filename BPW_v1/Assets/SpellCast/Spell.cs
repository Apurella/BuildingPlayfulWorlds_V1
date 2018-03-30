using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Player")
        {
            //Check runes
            if(col.tag == "Rune")
            {
                int name = int.Parse(col.name.Substring(4));

                FindObjectOfType<SpellCasting>().setRune(name, FindObjectOfType<SpellCasting>().getOrder());
                Debug.Log(FindObjectOfType<SpellCasting>().getCode());
            }

            Destroy(gameObject);
        }
    }
}
