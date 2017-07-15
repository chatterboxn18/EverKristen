using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("flicker", 0f, 0.5f);
	}

    void flicker(){
        this.GetComponent<Renderer>().enabled = !this.GetComponent<Renderer>().enabled;
    }
        //this.gameObject.SetActive(true);
    
	// Update is called once per frame
	void FixedUpdate () {
        
	}
}
