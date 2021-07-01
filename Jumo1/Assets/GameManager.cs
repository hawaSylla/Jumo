using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameEnded = false;

    bool LevelEnded = false;


    public float restartDelay = 5;

    public GameObject completeLevelUI;
    public GameObject gameOverUI;


    // Start is called before the first frame update
    void Start()
    {
        GameEnded = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndLevel()
    {
        if (LevelEnded == false)
        {

            completeLevelUI.SetActive(true);
            //SFXManager.sfxInstance.audio.PlayOneShot(SFXManager.sfxInstance.win);

            //Debug.Log("Level Complet !");
            //LevelEnded = true;
            //Invoke("Restart", restartDelay);
        }
    }

    public void GameOver()
    {
        if(GameEnded == false)
        {
            Debug.Log("Game over !");
            SFXManager.sfxInstance.audio.PlayOneShot(SFXManager.sfxInstance.Lose);

            gameOverUI.SetActive(true);
            GameEnded = true;
            //Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
