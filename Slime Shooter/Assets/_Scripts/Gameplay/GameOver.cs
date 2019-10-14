using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TutorialInGame tutorial;
    [SerializeField] private Button tutorialButton;

    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private GameObject gameOverScreen;

    public void CallGameOver()
    {
        StopAllCoroutines();        
        StartCoroutine(GameOverSequece());
    }

    private IEnumerator GameOverSequece()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 0;
        tutorial.enabled = false;
        tutorialButton.interactable = false;

        yield return new WaitForSecondsRealtime(2.0f);
        waveText.gameObject.SetActive(true);
        waveText.text = "GAME OVER";

        yield return new WaitForSecondsRealtime(2.0f);
        waveText.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        bestScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1;
    }
}