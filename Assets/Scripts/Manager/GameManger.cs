using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string winSceneName = "Win"; // Scene name for winning

    [SerializeField]
    private string gameOverSceneName = "GameOver"; // Scene name for GameOver

    private void OnEnable()
    {
        UIManager.OnScoreUpdated += CheckWinCondition; // Subscribe to the score update event
        UIManager.OnHealthUpdated += CheckGameOverCondition; // Subscribe to the health update event
    }

    private void OnDisable()
    {
        UIManager.OnScoreUpdated -= CheckWinCondition; // Unsubscribe from the score update event
        UIManager.OnHealthUpdated -= CheckGameOverCondition; // Unsubscribe from the health update event
    }

    private void CheckWinCondition(int score)
    {
        if (score >= 100)
        {
            SceneManager.LoadScene(winSceneName); // Load the win scene
        }
    }

    private void CheckGameOverCondition(float playerHealth)
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(gameOverSceneName); // Load the game-over scene
        }
    }
}
