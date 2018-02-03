using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour {

    public GameObject TryAgainText;
    public Text finalText, finalScoreText;

    private void Awake()
    {
        finalScoreText.gameObject.SetActive(false);
        finalText.gameObject.SetActive(false);
        TryAgainText.SetActive(false);
    }

    public void Start()
    {
        StartCoroutine(ShowFinalText());
    }

    IEnumerator ShowFinalText()
    {
        yield return new WaitForSeconds(1f);
        finalText.gameObject.SetActive(true);
        if (!GameController.instance.IsPlayerAlive())
            finalText.text = "game over";
        else
            finalText.text = "victory";
        yield return new WaitForSeconds(1f);
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "you got " + GameController.instance.score + " scores";
        yield return new WaitForSeconds(1f);
        TryAgainText.SetActive(true);
    }

}
