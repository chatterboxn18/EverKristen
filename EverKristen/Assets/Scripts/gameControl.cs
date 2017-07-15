using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameControl : MonoBehaviour {
    private GameObject enemy1, enemy2, enemy3, enemy4, enemy5;
    private GameObject scoreText;
    private int timesSpawned = 0;
    private int timer = 0;
    public GameObject enemy;
    public int timeToSpawn = 30;
    public int level = 0;
    public int score = 0;
    void Awake()
    {
        enemy1 = GameObject.Find("enemy1");
        enemy2 = GameObject.Find("enemy2");
        enemy3 = GameObject.Find("enemy3");
        enemy4 = GameObject.Find("enemy4");
        enemy5 = GameObject.Find("enemy5");
        scoreText = GameObject.Find("score");
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
        if (timer == timeToSpawn)
        {
            GameObject firstEnemy = (GameObject)Instantiate(enemy, enemy1.transform.position, Quaternion.identity);
            GameObject secondEnemy = (GameObject)Instantiate(enemy, enemy2.transform.position, Quaternion.identity);
            GameObject thirdEnemy = (GameObject)Instantiate(enemy, enemy3.transform.position, Quaternion.identity);
            GameObject fourthEnemy = (GameObject)Instantiate(enemy, enemy4.transform.position, Quaternion.identity);
            GameObject fifthEnemy = (GameObject)Instantiate(enemy, enemy5.transform.position, Quaternion.identity);
            timesSpawned++;
            timer = 0;
        }
        timer++;
		
	}

    void UpdateScore()
    {
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }

    void RandomEnemy()
    {
        
    }
}
