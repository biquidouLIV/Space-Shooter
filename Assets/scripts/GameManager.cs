using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    
    int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject pauseUI;

    private bool isGamePaused;

    private void Awake()
    {
        instance = this;

/*
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
 */
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void NextLevel()
    {
        int n = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((n + 1) % SceneManager.sceneCountInBuildSettings);
        Time.timeScale = 1;
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void ScoreUpdate()
    {
        score += 50;
        scoreText.text = "Score : " + score.ToString();
    }

    public void Pause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            if (gameOverUI.activeSelf)
            {
                return;
            }
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
        }
    }
}
