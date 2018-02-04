using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameObject menuPanel;

    public static UIController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        menuPanel.SetActive(false);
    }

    private void Update()
    {
        if (gameOverPanel.activeSelf)
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            menuPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
