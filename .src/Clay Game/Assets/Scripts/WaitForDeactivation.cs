﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaitForDeactivation : MonoBehaviour {
    public float duration;
    float t;
    public Image img;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (t < duration)
        {
            t += Time.deltaTime;
            if(img != null)
            {
                if (t > duration * 0.25f)
                    img.color = Color.Lerp(img.color, new Color(img.color.r, img.color.g, img.color.b, 0), duration * 1.25f * Time.deltaTime);
            }
           
        }
        else
        {
            t = 0;
            img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
            this.gameObject.SetActive(false);
        }
	}
}
