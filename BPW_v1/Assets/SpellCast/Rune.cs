using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    private Color baseColor;

    private ParticleSystem particleColor;

    private int delay = 0;

	void Start ()
    {
        particleColor = transform.GetChild(0).GetComponent<ParticleSystem>();
        baseColor = particleColor.startColor;
	}
	
	void Update ()
    {
        if (delay > 0) delay++;
        if (delay > 3)
        {
            delay = 0;
            disableEmission();
        }
	}

    public void wrongColor()
    {
        if (particleColor != null) particleColor.startColor = new Color(1, 0, 0);
    }

    public void winColor()
    {
        if (particleColor != null) particleColor.enableEmission = true;
        if (particleColor != null) particleColor.startColor = new Color(0, 1, 0);
    }

    public void resetColor()
    {
       if(particleColor != null) particleColor.startColor = baseColor;
    }

    public void lightUp()
    {
        if (particleColor != null) particleColor.enableEmission = true;
    }

    public void extinguish()
    {
        wrongColor();
        delay = 1;
    }

    public void disableEmission()
    {
        resetColor();
        if (particleColor != null) particleColor.enableEmission = false;
    }
}
