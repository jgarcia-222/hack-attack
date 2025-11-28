using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    [SerializeField] private playerControl playerController;
    public int progress;
    public Slider progressSlider;
    public GameObject player;

    public GameObject gameOverScreen;
    public GameObject LevelClearText;
    public GameObject introScreen;
    public static bool firstTry = true;

    private void Start()
    {
        token.ResetEvents();
        if(playerController!=null)
        { playerController.OnPlayerDie += GameOverScreen; }
        if (gameOverScreen.gameObject.activeSelf)
        { gameOverScreen.gameObject.SetActive(false); }
        if (LevelClearText.gameObject.activeSelf)
        { LevelClearText.gameObject.SetActive(false); }
        if (introScreen.gameObject.activeSelf)
        { introScreen.gameObject.SetActive(false); }


        progress = 0;
        progressSlider.value = 0;
        token.OnTokenCollect += IncreaseProgress;

        if (SceneManager.GetActiveScene().buildIndex == PlayerPrefs.GetInt("levelAt"))
        {
            if (firstTry)
            {
                Intro();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
        
        if (introScreen.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            introScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void IncreaseProgress(int amount) //handles level progress incrementation
    {
        progress += amount;
        progressSlider.value = progress;
        if (progress >= 100)
        {
            sfxManager.Play("scoreMax");
            LevelClearText.SetActive(true); //finish level text
        }
    }

    private void ResetProgress()
    {
        token.OnTokenCollect -= IncreaseProgress;

        if (playerController != null)
        { playerController.OnPlayerDie -= GameOverScreen; }
    }

    public void Intro()
    {
        Time.timeScale = 0;
        introScreen.SetActive(true);
    }

    void GameOverScreen()
    {
        firstTry = false;
        gameOverScreen.SetActive(true);
        if (playerController != null)
        {
            playerController.OnPlayerDie -= GameOverScreen;
        }
        Time.timeScale = 0;
    }
    public void ResetGame()
    {
        gameOverScreen.SetActive(false); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        firstTry = true; 
        SceneManager.LoadScene("levelSelect");
        Time.timeScale = 1;
    }

}