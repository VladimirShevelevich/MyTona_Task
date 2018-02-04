using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject menuPanel;
    public GameObject menuBackPanel;
    public GameObject optionsPanel;
    public Text muteText;

    public static UIController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        menuPanel.SetActive(false);
        menuBackPanel.SetActive(false);
        optionsPanel.SetActive(false);
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
            menuBackPanel.SetActive(true);
            optionsPanel.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Options()
    {
        if (!optionsPanel.activeSelf)
        {
            menuBackPanel.SetActive(false);
            optionsPanel.SetActive(true);
            UpdateMuteButton();
        }
        else
        {
            menuBackPanel.SetActive(true);
            optionsPanel.SetActive(false);
        }
    }

    public void Mute()
    {
        SoundController.instance.Mute();
        UpdateMuteButton();
    }

    void UpdateMuteButton()
    {
        if (SoundController.MUTE)
            muteText.text = "unmute";
        else
            muteText.text = "mute";
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
