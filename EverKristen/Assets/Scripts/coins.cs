using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour {
    public int value = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }
}
