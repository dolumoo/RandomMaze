using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject victoryUI;
    public GameObject loadingUI;
    public GameObject failUI;

    private void Start()
    {
        loadingUI.SetActive(true);
        victoryUI.SetActive(false);
    }

    public void endLoading()
    {
        loadingUI.SetActive(false);
    }
    public void PlayerReachedGoal()
    {
        Time.timeScale = 0;
        victoryUI.SetActive(true);
    }
    public void PlayerFailedGoal()
    {
        Time.timeScale = 0;
        failUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
