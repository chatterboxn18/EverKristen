using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    //private bool hitRightWall = false;
    //private bool hitLeftWall = false;
    // Use this for initialization
    public GameObject poop;
    private int timer = 0;
    public float movementSpeed = 5;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.RightArrow) ^ Input.GetKey(KeyCode.LeftArrow))
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
            
        }
        if (timer == 4)
        {
            GameObject bullets = (GameObject)Instantiate(poop, new Vector3(0, 1f, 0) + this.transform.position, Quaternion.identity);
            timer = 0;
        }
        timer++;
        Debug.Log(timer);
        
        
	}

}
