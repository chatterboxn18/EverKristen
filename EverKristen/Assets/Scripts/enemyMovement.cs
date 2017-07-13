using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    public float speed = 7f;
    public float life = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Translate(new Vector2(0, -speed * Time.deltaTime));
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "bullet")
        {
            this.life = this.life - collision.transform.GetComponent<poopbullet>().damage;
            if (this.life <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        
    }


}
