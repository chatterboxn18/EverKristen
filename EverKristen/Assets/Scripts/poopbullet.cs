using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poopbullet : MonoBehaviour {
    public float bulletSpeed = 5f;
    public float damage = 1f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(new Vector2(0, bulletSpeed * Time.deltaTime));
	}

   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "bullet")
        {
            Destroy(this.gameObject);
        }
        
    }
}
