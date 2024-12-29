using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static event System.Action<int> OnScoreUpdated; // Event to notify score updates
    public static event System.Action<float> OnHealthUpdated; // Event to notify health updates

    [SerializeField]
    private TextMeshProUGUI scoreText; // Reference to the score display

    [SerializeField]
    private Image healthBar; // Reference to the health bar UI

    public static int currentScore { get; private set; } = 0;

    private void Awake()
    {
        if (scoreText == null)
        {
            Debug.LogError("TextMeshProUGUI component is not assigned! Please attach it to the UIManager.");
        }

        if (healthBar == null)
        {
            Debug.LogError("Health bar Image component is not assigned! Please attach it to the UIManager.");
        }
    }

    public static void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        OnScoreUpdated?.Invoke(currentScore); // Notify listeners about the score change
    }

    public void UpdateHealthBar(float playerHealth)
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = playerHealth / 100f; // Update the health bar
            OnHealthUpdated?.Invoke(playerHealth); // Notify listeners about the health change
        }
    }

    private void OnEnable()
    {
        OnScoreUpdated += UpdateScoreDisplay; // Subscribe to the score update event
    }

    private void OnDisable()
    {
        OnScoreUpdated -= UpdateScoreDisplay; // Unsubscribe from the score update event
    }

    private void UpdateScoreDisplay(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {newScore}";
        }
    }
}
