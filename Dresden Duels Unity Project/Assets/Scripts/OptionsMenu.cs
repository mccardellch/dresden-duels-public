using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenuUI;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject endMenuUI;
    [SerializeField] private  TMP_Text endText;

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

    public void ActivateEndMenu(string loser)
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        endMenuUI.SetActive(true);
        endText.text = loser + " has unfortunately lost the battle for Chicago.";
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
