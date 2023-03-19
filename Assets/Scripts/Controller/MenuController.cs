using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _creepCount;
    public int creepCount = 0;

    private float _startTime;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            instance = null;
        }
        else
        {
            instance = this;
        }
        _startTime = Time.time;
    }

    private void Update()
    {
        float currentTime = Time.time - _startTime;
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = Mathf.Floor(currentTime % 60).ToString("00");
        _timeText.text = minutes + ":" + seconds;
        _creepCount.text = creepCount.ToString();
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
