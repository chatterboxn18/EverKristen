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
        if (this.name.Contains("iceCream"))
        {
            if (collider.transform.tag == "player")
            {
                collider.GetComponent<movement>().level++;
            }
        }
        else if (this.name.Contains("sushi"))
        {
            if (collider.transform.tag == "player")
            {
                collider.transform.GetComponent<movement>().BlastOff();
                //collider.GetComponent<movement>();
            }
        }
        if (collider.transform.name == "destroyLeftovers")
        {
            Destroy(this.gameObject);
        }
    }
}
