using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _creepCount;

    private float _startTime;

    private void Start()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        float currentTime = Time.time - _startTime;
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = Mathf.Floor(currentTime % 60).ToString("00");
        _timeText.text = minutes + ":" + seconds;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }


}
