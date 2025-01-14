using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    [Tooltip("Player's starting health.")]
    [SerializeField]
    public float PlayerHealth;

    [SerializeField]
    [Tooltip("Input action for player movement.")]
    private InputAction move = new InputAction(type: InputActionType.Value, expectedControlType: nameof(Vector2));

    [SerializeField]
    [Tooltip("Prefab for spawning lasers.")]
    private GameObject LaserPrefab;

    private UIManager uiManager;
    private Vector3 movementVector;

    private void Awake()
    {
        uiManager = FindAnyObjectByType<UIManager>();
    }

    private void OnEnable()
    {
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    public override void FixedUpdateNetwork()
    {
        if (!Object.HasStateAuthority)
        {
            return;
        }

        Vector2 moveInput = move.ReadValue<Vector2>();
        movementVector = new Vector3(moveInput.x, moveInput.y, 0) * Constants.Player_speed * Runner.DeltaTime;
        transform.position += movementVector;

        if (Input.GetMouseButtonDown(0))
        {
            Laser();
        }
    }

    public void Take_Damage(float damage)
    {
        if (!Object.HasStateAuthority)
        {
            return;
        }

        PlayerHealth -= damage;
        uiManager.UpdateHealthBar(PlayerHealth);

        if (PlayerHealth <= 0)
        {
            Runner.Despawn(Object);
        }
    }

    public void Healing(float healAmount)
    {
        if (!Object.HasStateAuthority)
        {
            return;
        }

        PlayerHealth += healAmount;
        PlayerHealth = Mathf.Clamp(PlayerHealth, 0, 100);
        uiManager.UpdateHealthBar(PlayerHealth);
    }

    private void Laser()
    {
        if (!Object.HasStateAuthority)
        {
            return;
        }

        Vector3 laserPosition = transform.position + Vector3.up * 1f;
        Quaternion laserRotation = Quaternion.identity;
        Runner.Spawn(LaserPrefab, laserPosition, laserRotation, Object.InputAuthority);
    }
}
