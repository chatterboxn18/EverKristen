using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class gameControl : MonoBehaviour {
    private GameObject enemy1, enemy2, enemy3, enemy4, enemy5;
    [SerializeField] private movement player;
    [SerializeField] private Text scoreText;
    private List<int> enemies;
    private Dictionary<int, EnemyMovement> enemyDict;
    private int timer = 0;
    public int spawnedLines;
    public EnemyMovement bearEnemy1, bearEnemy2, bearEnemy3, bearEnemy4, bearEnemy5;
    [SerializeField] private EnemyMovement enemy;
    public int timeToSpawn = 30;
    public int level = 0;
    public bool allowSpawn = true;
    public int score = 0;


    void Awake()
    {
        enemyDict = new Dictionary<int, EnemyMovement>();
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
            if (player.isBlasted)
            {
                enemy.speed = 60;
            }
            var firstEnemy = Instantiate(enemy, new Vector2(-95, 70), Quaternion.identity);
            enemy = enemyDict[enemies[Random.Range(0, (enemies.Count))]];
            if (player.isBlasted)
            {
                enemy.speed = 60;
            }
            var secondEnemy = Instantiate(enemy, new Vector2(-80, 70), Quaternion.identity);
            enemy = enemyDict[enemies[Random.Range(0, (enemies.Count))]];
            if (player.isBlasted)
            {
                enemy.speed = 60;
            }
            var thirdEnemy = Instantiate(enemy, new Vector2(-65, 70), Quaternion.identity);
            enemy = enemyDict[enemies[Random.Range(0, (enemies.Count))]];
            if (player.isBlasted)
            {
                enemy.speed = 60;
            }
            var fourthEnemy = Instantiate(enemy, new Vector2(-50, 70), Quaternion.identity);
            enemy = enemyDict[enemies[Random.Range(0, (enemies.Count))]];
            if (player.isBlasted)
            {
                enemy.speed = 60;
            }
            var fifthEnemy = Instantiate(enemy, new Vector2(-35, 70), Quaternion.identity);
            spawnedLines++;
            timer = 0;
        }
        timer++;
        if (spawnedLines == 25)
        {
            NewLevel();
        }
		
	}

    void RandomEnemy(EnemyMovement enemy)
    {
        int number = enemies[Random.Range(0, (enemies.Count) - 1)];
        enemy = enemyDict[enemies[Random.Range(0, (enemies.Count) - 1)]];
        
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
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
