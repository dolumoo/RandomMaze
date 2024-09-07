using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject victoryUI;
    public GameObject loadingUI;

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
        victoryUI.SetActive(true);
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
