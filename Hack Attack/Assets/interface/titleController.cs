using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class titleController : MonoBehaviour
{
    public Button buttonLogs;
    public GameObject winScreen;
    public static bool winScreenSeen = false;
    private void Start()
    {
        if(PlayerPrefs.GetInt("levelAt") < 10 || winScreenSeen)
        {
            winScreen.SetActive(false);
        }
        if(PlayerPrefs.GetInt("levelAt") == 10)
        {
            buttonLogs.interactable = true;
            if(winScreenSeen == false)
            {
                winScreen.SetActive(true);
                winScreenSeen = true;
                Time.timeScale = 0;
            }
        }

    }

    private void Update()
    {
        if (winScreen.gameObject.activeSelf && Input.anyKeyDown)
        {
            winScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }


    public void OnClickStart()
    {
        SceneManager.LoadScene("levelSelect");
    }
    public void OnClickReset()
    {
        PlayerPrefs.SetInt("levelAt", 2);
    }

    public void OnClickLogs()
    {
        SceneManager.LoadScene("hackLogs");
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
