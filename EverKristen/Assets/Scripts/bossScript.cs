using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour {
    float bossHP = 0;
	// Use this for initialization
	void Start () {
		if (this.gameObject.name == "Maria_boss")
        {
            this.bossHP = 70;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (this.bossHP <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            this.bossHP -= collision.gameObject.GetComponent<poopbullet>().damage;
        }
    }
}
