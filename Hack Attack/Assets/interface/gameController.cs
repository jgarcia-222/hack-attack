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

    private void Start()
    {
        token.ResetEvents();
        if(playerController!=null)
        { playerController.OnPlayerDie += GameOverScreen; }
        if (gameOverScreen.gameObject.activeSelf)
        { gameOverScreen.gameObject.SetActive(false); }
        if (LevelClearText.gameObject.activeSelf)
        { LevelClearText.gameObject.SetActive(false); }


        progress = 0;
        progressSlider.value = 0;
        token.OnTokenCollect += IncreaseProgress;
    }

    void IncreaseProgress(int amount) //handles level progress incrementation
    {
        progress += amount;
        progressSlider.value = progress;
        //Debug.Log("gameController progress: " + progress);
        if (progress >= 100)
        {
            sfxManager.Play("scoreMax");
            LevelClearText.SetActive(true); //finish level text
            //Debug.Log("Hack Complete");
        }
    }

    private void ResetProgress()
    {
        token.OnTokenCollect -= IncreaseProgress;

        if (playerController != null)
        { playerController.OnPlayerDie -= GameOverScreen; }
    }

    void GameOverScreen()
    {
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
        SceneManager.LoadScene("levelSelect");
        Time.timeScale = 1;
    }

}