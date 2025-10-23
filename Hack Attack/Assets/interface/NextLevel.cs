using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    private int score;
    public gameController controller;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        if (controller == null) 
        { controller = FindObjectOfType<gameController>(); }
    }

    // Update is called once per frame
    void Update()
    {
        score = controller.progress;
    }
    public void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        Debug.Log("NextLevel score - " + score);

        if (other.gameObject.tag == "Player" && score>=100)
        {
            
            if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                Debug.Log("You win!");
                SceneManager.LoadScene("title"); //implement a win screen
            }
            else
            {
                SceneManager.LoadScene(nextSceneLoad); //go to next level
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))//sets int for Index
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }

}
