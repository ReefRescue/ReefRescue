using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public bool GameIsPaused = false;
    private GameObject PauseMenu;

    void Awake()
    {
        PauseMenu = GameObject.Find("PauseCanvas");
    }

    void Start()
    {
        // Resume at start of game
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        // PauseMenu.transform.localScale = new Vector3(0, 0, 0);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("resuming");
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        // PauseMenu.transform.localScale = new Vector3(1, 1, 1);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("pausing");
    }
}
