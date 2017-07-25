using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    
    private GameObject scorePanel, gameOver, background;
    private int timer = 0;
    private bool isDragged = false, reseting = false;
    private GameObject edgeLeft, edgeRight;
    
    private int resetTime = 0;
    private int blastLinesMax = 0;

    /*
     * Public Items below
     *  
     * */
    public Vector3 screenPoint, offset;
    public int level = 1;
    public float movementSpeed = 5, bulletSpeed = 5;
    public int rushMax = 50;
    public GameObject playerBullets;
    public bool isBlasted = false;
    public Animator blastingImage;

    void Awake()
    {
        gameOver = GameObject.Find("gameOver");
        gameOver.gameObject.SetActive(false);
        scorePanel = GameObject.Find("Game Control");
        edgeLeft = GameObject.Find("Edge1");
        edgeRight = GameObject.Find("Edge2");
        background = GameObject.Find("Quad");
    }
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {

            
            Debug.Log(Input.mousePosition.x);
            isDragged = true;
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
        if (isDragged == true)
        {

            if (!(offset.x + Camera.main.ScreenToWorldPoint(Input.mousePosition).x <= edgeLeft.transform.position.x) && !(offset.x + Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= edgeRight.transform.position.x))
            {
                this.transform.position = new Vector3(offset.x + Camera.main.ScreenToWorldPoint(Input.mousePosition).x, this.transform.position.y, this.transform.position.z);
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
        if (timer >= bulletSpeed)
        {
            
            if (!isBlasted && !reseting)
            {
                GameObject bullets = (GameObject)Instantiate(playerBullets.transform.GetChild(level - 1).gameObject, new Vector3(0, 7f, 0) + this.transform.position, Quaternion.identity);
            }
            timer = 0;
        }

        /*BlastOffTimer will update every frame to send this character flying through the air and invulnerable to enemies*/
        if (this.isBlasted)
        {
            this.timer = this.timer + 2;
            Debug.Log(this.scorePanel.GetComponent<gameControl>().spawnedLines + " " + this.blastLinesMax);
            
            if (this.blastLinesMax == this.scorePanel.GetComponent<gameControl>().spawnedLines)
            {
                Debug.Log("does this happen");
                BlastOn();
            }

        }
        else
        {
           if (reseting)
            {
                if (resetTime >= 100)
                {
                    this.resetTime = 0;
                    this.reseting = false;
                    this.scorePanel.GetComponent<gameControl>().allowSpawn = true;
                    this.scorePanel.GetComponent<gameControl>().timeToSpawn = 150;
                }
                else
                {
                    this.resetTime++;
                }
            }
            timer++;
        }
       
        
        
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "coins")
        {
            scorePanel.GetComponent<gameControl>().score += other.transform.GetComponent<coins>().value;
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "enemy")
        {
            if (isBlasted || reseting)
            {
                other.GetComponent<enemyMovement>().produceItem();
                Destroy(other.gameObject);
            }
            else
            {
                gameOver.gameObject.SetActive(true);
                this.scorePanel.GetComponent<gameControl>().allowSpawn = false;
                Destroy(this.gameObject);
            }
            
       
        }
    }

    public void BlastOff()
    {
        if (!isBlasted)
        {
            this.isBlasted = true;
            this.scorePanel.GetComponent<gameControl>().timeToSpawn = 50;
            this.blastLinesMax = this.scorePanel.GetComponent<gameControl>().spawnedLines + 7;
            if (blastLinesMax >= 25)
            {
                blastLinesMax = blastLinesMax - 25;
            }
            this.background.GetComponent<bgScroll>().scrollSpeed = 0.5f;
        }
        else
        {
            if(!this.isBlasted) {
                this.isBlasted = true;
                this.reseting = false;
                this.blastLinesMax = 2;
            }
            this.blastLinesMax += 2;
            if (this.blastLinesMax >= 25)
            {
                blastLinesMax = blastLinesMax - 25;
            }
        }
        
    }

    private void BlastOn()
    {
        this.background.GetComponent<bgScroll>().scrollSpeed = 0.1f;
        this.scorePanel.GetComponent<gameControl>().allowSpawn = false;
        this.isBlasted = false;
        this.reseting = true;
        this.blastLinesMax = 0;
    }
    
}
