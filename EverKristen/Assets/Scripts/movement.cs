using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    //private bool hitRightWall = false;
    //private bool hitLeftWall = false;
    // Use this for initialization
    private GameObject scorePanel;
    public GameObject poop;
    private int timer = 0;
    //private Vector3 originalMousePosition;
    private float offsetX;
    public float movementSpeed = 5;
    private GameObject edgeLeft, edgeRight;
    public Vector3 screenPoint, offset;
    private bool isDragged = false;
    void Awake()
    {
        scorePanel = GameObject.Find("Game Control");
        edgeLeft = GameObject.Find("Edge1");
        edgeRight = GameObject.Find("Edge2");
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("this went first");
            offsetX = this.transform.position.x - Input.mousePosition.x;
            Debug.Log(Input.mousePosition.x);
            isDragged = true;
            
        }
        if (isDragged == true)
        {
            Debug.Log("Then a lot of this");
            Debug.Log(offsetX);
            //float lagged = offsetX / 5f;
            if (!(offsetX + Input.mousePosition.x <= edgeLeft.transform.position.x) && !(offsetX + Input.mousePosition.x >= edgeRight.transform.position.x))
            {
                this.transform.position = new Vector3(offsetX + Input.mousePosition.x, this.transform.position.y, this.transform.position.z);
            }
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragged = false;
        }
		/*if (Input.GetKey(KeyCode.RightArrow) ^ Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.RightArrow)) //&& !hitRightWall)
            {
                this.transform.Translate(new Vector2(this.movementSpeed * Time.deltaTime, 0));
                //hitLeftWall = false;

            }
            else
            {
                this.transform.Translate(new Vector2(-this.movementSpeed * Time.deltaTime, 0));
            }
            
        }*/
        if (timer == 20)
        {
            GameObject bullets = (GameObject)Instantiate(poop, new Vector3(0, 10f, 0) + this.transform.position, Quaternion.identity);
            timer = 0;
        }
        timer++;
       
        
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "enemy")
        {
            Debug.Log("GameOver");
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "coins")
        {
            scorePanel.GetComponent<gameControl>().score += other.transform.GetComponent<coins>().value;
            Destroy(other.gameObject);
        }
    }
    
}
