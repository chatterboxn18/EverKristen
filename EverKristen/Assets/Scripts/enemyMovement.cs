using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    //private GameObject score;
    public GameObject boba; 
    public float speed = 7f;
    public float life = 2f;
    public int points = 100;
	// Use this for initialization
	void Start () {
        //score = GameObject.Find("Game Control"); 
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
               // score.GetComponent<gameControl>().score += this.points;
                GameObject bobas = (GameObject)Instantiate(boba, this.transform.position, Quaternion.identity);
                bobas.GetComponent<Rigidbody2D>().AddForce(transform.up * 2f, ForceMode2D.Impulse);
                Destroy(this.gameObject);
            }
        }
        if (collision.transform.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
        
    }



}
