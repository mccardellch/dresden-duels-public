using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;
    [SerializeField] private bool isMuted;

    [SerializeField] private GameObject gameEnvironment;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActivateMenu();
        } else {
            DeactivateMenu();
        }
    } 

    public void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        gameEnvironment.SetActive(false);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        gameEnvironment.SetActive(true);
        isPaused = false;
    }


    public void ToggleMusic(bool _isMuted)
    {     
        AudioListener.pause = _isMuted;
    }

    public void QuitGame()
    {
        Debug.Log("Player quit game");
        Application.Quit();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
