using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    //private GameObject score;
    public GameObject boba, sushi, iceCream;
    public Sprite shotFace;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "bullet")
        {
            this.life = this.life - collision.transform.GetComponent<poopbullet>().damage;
            this.GetComponent<SpriteRenderer>().sprite = shotFace;
            if (this.life <= 0)
            {
                // score.GetComponent<gameControl>().score += this.points;
                produceItem();
                Destroy(this.gameObject);
            }
        }
        if (collision.transform.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
        
    }

    public void produceItem()
    {
        int number = Random.Range(0, 50);
        if (number == 30)
        {
            GameObject coins = (GameObject)Instantiate(sushi, this.transform.position, Quaternion.identity);
            coins.GetComponent<Rigidbody2D>().AddForce(transform.up * 2f, ForceMode2D.Impulse);
        }
        else if (number == 20)
        {
            GameObject iceCreams = (GameObject)Instantiate(iceCream, this.transform.position, Quaternion.identity);
            iceCreams.GetComponent<Rigidbody2D>().AddForce(transform.up * 2f, ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log("I came from" + this.gameObject.name);
            GameObject bobas = (GameObject)Instantiate(boba, this.transform.position, Quaternion.identity);
            bobas.GetComponent<Rigidbody2D>().AddForce(transform.up * 2f, ForceMode2D.Impulse);
        }
    }



}
