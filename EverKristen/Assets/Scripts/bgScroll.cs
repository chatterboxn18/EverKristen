using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroll : MonoBehaviour {
    public float scrollSpeed;
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(0, Time.time * scrollSpeed);
        this.GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
