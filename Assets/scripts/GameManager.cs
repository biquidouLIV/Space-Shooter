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
    [SerializeField] GameObject pauseButton;

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
    public void NextLevel()
    {
        int n = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((n + 1) % SceneManager.sceneCountInBuildSettings);
        Time.timeScale = 1;
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
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
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        pauseButton.SetActive(false);

    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        pauseButton.SetActive(true);
    }
}