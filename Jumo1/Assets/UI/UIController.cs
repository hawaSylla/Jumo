using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    // [Header("Config")]
    public Text scoretxt;
    public Text finScore;
    public Text healthtxt;
    public Text timer;
    public Text highscore;


    private float currentTime = 0f;
    public float startingTime = 60f;

    private int defaultHealth = 5;
    public int health = 5;
    private int score = 0;

    public GameManager GM;
    private UIController ui;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        highscore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        health = defaultHealth;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoretxt.text = "Score: " + score;
        healthtxt.text = "Health: " + health;
        finScore.text = "Score: " + score;

        currentTime -= 1 * Time.deltaTime;

        timer.text = currentTime.ToString("0");

        if (currentTime < 30)
        {
            timer.color = Color.yellow;

        }

        if (currentTime < 11)
        {
            timer.color = Color.red;

        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            timer.color = Color.black;
            GM.GameOver();

        }
    }

    public void ScoreAddPoint(int i)
    {
        score += i;
        PlayerPrefs.SetInt("Highscore", score);
    }

    public void Damage(int i)
    {
        if (health > 0)
        {
            health--;
        }

        if(health <= 0)
        {
            FindObjectOfType<GameManager>().GameOver();

        }
    }

    public void ResetHealth()
    {
        health = defaultHealth;
    }
}
