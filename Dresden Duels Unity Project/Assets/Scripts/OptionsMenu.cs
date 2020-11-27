using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenuUI;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject endMenuUI;

    void Start()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

    public void ActivateMenu()
    {
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void DeactivateMenu()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void ActivateEndMenu()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        endMenuUI.SetActive(true);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Player quit game");
    }
    public void QuitGame()
    {
        Debug.Log("Player quit game");
        Application.Quit();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
