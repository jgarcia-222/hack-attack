using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 0; i<levelButtons.Length; i++)
        {
            if (i+2 > levelAt)
            { levelButtons[i].interactable = false; }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    
    //sends user to title screen
    public void OnClickBack()
    {
        SceneManager.LoadScene("title");
    }
    
    //buttons will load corresponding levels
    public void OnClickLevel1()
    {
        if (levelButtons[0])
        { SceneManager.LoadScene("level1"); }
    }
    public void OnClickLevel2()
    {
        if (levelButtons[0])
        { SceneManager.LoadScene("level2"); }
    }
    public void OnClickLevel3()
    {
        if (levelButtons[0])
        { SceneManager.LoadScene("level3"); }
    }
    public void OnClickLevel4()
    {
        if (levelButtons[0])
        { SceneManager.LoadScene("level4"); }
    }
    public void OnClickLevel5()
    {
        if (levelButtons[0])
        { SceneManager.LoadScene("level5"); }
    }
    public void OnClickLevel6()
    {
        if (levelButtons[0])
        { SceneManager.LoadScene("level6"); }
    }
    public void OnClickLevel7()
    {
        if (levelButtons[0])
        { SceneManager.LoadScene("level7"); }
    }
    public void OnClickLevel8()
    {
        if (levelButtons[0])
        { SceneManager.LoadScene("level8"); }
    }

    
}
