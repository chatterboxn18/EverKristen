using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameControl : MonoBehaviour {
    private GameObject enemy1, enemy2, enemy3, enemy4, enemy5, player;
    private GameObject scoreText;
    private List<int> enemies;
    private Dictionary<int, GameObject> enemyDict;
    private int timer = 0;
    public int spawnedLines;
    public GameObject bearEnemy1, bearEnemy2, bearEnemy3, bearEnemy4, bearEnemy5;
    public GameObject enemy;
    public int timeToSpawn = 30;
    public int level = 0;
    public bool allowSpawn = true;
    public int score = 0;


    void Awake()
    {
        enemy1 = GameObject.Find("enemy1");
        enemy2 = GameObject.Find("enemy2");
        enemy3 = GameObject.Find("enemy3");
        enemy4 = GameObject.Find("enemy4");
        enemy5 = GameObject.Find("enemy5");
        scoreText = GameObject.Find("score");
        player = GameObject.Find("kristen1");
        enemyDict = new Dictionary<int, GameObject>();
        enemies = new List<int>();
        enemyDict.Add(1, bearEnemy1);
        enemyDict.Add(2, bearEnemy2);
        enemyDict.Add(3, bearEnemy3);
        enemyDict.Add(4, bearEnemy4);
        enemyDict.Add(5, bearEnemy5);
    }
	// Use this for initialization
	void Start () {
        
        enemies.Add(1);
        enemies.Add(1);
        enemies.Add(2);
        
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
        if (timer >= timeToSpawn && allowSpawn)
        {
            
            enemy = enemyDict[enemies[Random.Range(0, (enemies.Count))]];
            if (player.GetComponent<movement>().isBlasted)
            {
                enemy.GetComponent<enemyMovement>().speed = 60;
            }
            GameObject firstEnemy = (GameObject)Instantiate(enemy, enemy1.transform.position, Quaternion.identity);
            enemy = enemyDict[enemies[Random.Range(0, (enemies.Count))]];
            if (player.GetComponent<movement>().isBlasted)
            {
                enemy.GetComponent<enemyMovement>().speed = 60;
            }
            GameObject secondEnemy = (GameObject)Instantiate(enemy, enemy2.transform.position, Quaternion.identity);
            enemy = enemyDict[enemies[Random.Range(0, (enemies.Count))]];
            if (player.GetComponent<movement>().isBlasted)
            {
                enemy.GetComponent<enemyMovement>().speed = 60;
            }
            GameObject thirdEnemy = (GameObject)Instantiate(enemy, enemy3.transform.position, Quaternion.identity);
            enemy = enemyDict[enemies[Random.Range(0, (enemies.Count))]];
            if (player.GetComponent<movement>().isBlasted)
            {
                enemy.GetComponent<enemyMovement>().speed = 60;
            }
            GameObject fourthEnemy = (GameObject)Instantiate(enemy, enemy4.transform.position, Quaternion.identity);
            enemy = enemyDict[enemies[Random.Range(0, (enemies.Count))]];
            if (player.GetComponent<movement>().isBlasted)
            {
                enemy.GetComponent<enemyMovement>().speed = 60;
            }
            GameObject fifthEnemy = (GameObject)Instantiate(enemy, enemy5.transform.position, Quaternion.identity);
            spawnedLines++;
            timer = 0;
        }
        timer++;
        if (spawnedLines == 25)
        {
            NewLevel();
        }
		
	}

    void RandomEnemy(GameObject enemy)
    {
        int number = enemies[Random.Range(0, (enemies.Count) - 1)];
        enemy = enemyDict[enemies[Random.Range(0, (enemies.Count) - 1)]];
        
    }

    void UpdateScore()
    {
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }

    void NewLevel()
    {
        
        spawnedLines = 0;
        level++;
        for (int i =0; i < level; i++)
        {
            enemies.Add(level);
        }
        enemies.Add(level + 1);
    }
}
