using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles player movement, health, and laser shooting.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Player's starting health.")]
    public static float PlayerHealth = 100f;

    [SerializeField]
    [Tooltip("Input action for player movement.")]
    InputAction move = new InputAction(type: InputActionType.Value, expectedControlType: nameof(Vector2));

    [SerializeField]
    [Tooltip("Prefab for spawning lasers.")]
    private GameObject LaserPrefab;

    private UIManager uiManger;

    /// <summary>
    /// Initializes references.
    /// </summary>
    private void Awake()
    {
        uiManger = FindAnyObjectByType<UIManager>();
    }

    /// <summary>
    /// Enables the movement input action.
    /// </summary>
    private void OnEnable()
    {
        move.Enable();
    }

    /// <summary>
    /// Disables the movement input action.
    /// </summary>
    private void OnDisable()
    {
        move.Disable();
    }

    /// <summary>
    /// Updates the player's position and handles laser shooting.
    /// </summary>
    private void Update()
    {
        // Handle player movement
        Vector2 moveDirection = move.ReadValue<Vector2>();
        Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) * Constants.Player_speed * Time.deltaTime;
        transform.position += movementVector;

        // Shoot a laser on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Laser();
        }
    }

    /// <summary>
    /// Reduces player's health when taking damage.
    /// </summary>
    /// <param name="_damge">Amount of damage to take.</param>
    public void Take_Damge(float _damge)
    {
        PlayerHealth -= _damge;
        uiManger.UpdateHealthBar(PlayerHealth);

        // Check if the player's health reaches zero
        if (PlayerHealth <= 0)
        {
            Destroy(this);
        }
    }

    /// <summary>
    /// Heals the player and updates the health bar.
    /// </summary>
    /// <param name="healhPoints">Amount of health to heal.</param>
    public void Healing(float healhPoints)
    {
        PlayerHealth += healhPoints;
        PlayerHealth = Mathf.Clamp(PlayerHealth, 0, 100);
        uiManger.UpdateHealthBar(PlayerHealth);
    }

    /// <summary>
    /// Spawns a laser above the player.
    /// </summary>
    private void Laser()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Instantiate(LaserPrefab, pos, Quaternion.identity);
    }
}
