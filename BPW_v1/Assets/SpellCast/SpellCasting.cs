using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    private Animation anim;
    public GameObject spell;
    private bool isCasting = false;
    private float castDelay = 0;
    public float speed = 2;
    public Camera camera;
    public GameObject spellSpawn;

    public GameObject bossRunes;

    private int[] order = new int[] {-1, -1, -1, -1, -1};
    private int[] rightOrder = new int[] {0, 1, 2, 3, 4};

    private bool win = false;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animation>();
        turnOffOrder();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !isCasting)
        {
            //Spell Object
            GameObject spellParticle = Instantiate(spell);

            //Placement
            spellParticle.transform.position = spellSpawn.transform.position;
            spellParticle.transform.rotation = camera.transform.rotation;
            
            //Movement
            spellParticle.GetComponent<Rigidbody>().AddForce(spellParticle.transform.forward * speed);
            spellParticle.transform.Rotate(new Vector3(0, -90, 0));

            //Animation
            anim.Play();

            //Sound
            GetComponent<AudioSource>().Play();

            //Safety
            isCasting = true;
            castDelay = 1;
        }
        if (castDelay > 0) castDelay++;
        if (castDelay > 10) castDelay = 0;
        if (!anim.isPlaying) isCasting = false;

        //I came up with way too difficult mechanics to defeat the boss, A lot of the code is done with help from Can.
        for (int i = 0; i < order.Length; i++) if(order[i] != -1) bossRunes.transform.GetChild(order[i]).GetComponent<Rune>().lightUp();
    }

    public void setRune(int value, int index)
    {
        if (!win)
        {
            if (order[index] == -1 && !alreadyLightUp(value)) order[index] = value;

            int count = 0;
            for (int i = 0; i < order.Length; i++) if (order[i] != -1) count++;
            if (count >= order.Length) resetOrder();
        }
    }

    public bool alreadyLightUp(int value)
    {
        for (int i = 0; i < order.Length; i++) if (order[i] == value) return true;
        return false;
    }

    public void turnOffOrder()
    {
        if (!win)
        {
            for (int i = 0; i < order.Length; i++)
            {
                order[i] = -1;
                bossRunes.transform.GetChild(i).GetComponent<Rune>().disableEmission();
            }
        }
    }

    public void resetOrder()
    {
        int rightness = 0;
        for(int i = 0; i < order.Length; i++)
        {
            if(rightOrder[i] == order[i]) rightness++;
        }
        if (rightness >= order.Length)
        {
            defeatGame();
            win = true;
            for (int i = 0; i < order.Length; i++) bossRunes.transform.GetChild(i).GetComponent<Rune>().winColor();
            return;
        }

        if (!win)
        {
            for (int i = 0; i < order.Length; i++)
            {
                order[i] = -1;
                bossRunes.transform.GetChild(i).GetComponent<Rune>().lightUp();
                bossRunes.transform.GetChild(i).GetComponent<Rune>().extinguish();
            }
        }
    }

    public void defeatGame()
    {

    }

    public int getOrder()
    {
        for (int i = 0; i < order.Length; i++) if(order[i] == -1) return i;
        resetOrder();
        return -1;
    }

    public string getCode()
    {
        string code = "";
        for (int i = 0; i < order.Length; i++) code += order[i] + " | ";
        return code;
    }
}
