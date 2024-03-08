using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    public GameObject endUI;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();
        if(elapsedTime >= 120) //this line controls game length
            EndGame();
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "" + timerString;
    }

    void EndGame()
    {
        endUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
