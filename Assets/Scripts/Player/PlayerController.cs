using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    [Tooltip("this player Health when start the game ")]
    public static float PlayerHealth=100f;
  

    [SerializeField]
    InputAction move = new InputAction(type: InputActionType.Value, expectedControlType: nameof(Vector2));

    [SerializeField]
    [Tooltip("this for laser Spwaner")]
    private GameObject LaserPrefab;

    private UIManager uiManger;

    private void Awake()
    {
        uiManger = FindAnyObjectByType<UIManager>();
    }
    void OnEnable()
    {
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    void Update()
    {
        Vector2 moveDirection = move.ReadValue<Vector2>();
        Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) * Constants.Player_speed * Time.deltaTime;
        transform.position += movementVector;
        if (Input.GetMouseButtonDown(0)) // shoot laser on mouse click
        {
            Laser();
        }
       

    }
    public void Take_Damge(float _damge)
    {
       PlayerHealth-=_damge;
       uiManger.UpdateHealthBar(PlayerHealth);
        if (PlayerHealth <= 0)
        {
            Destroy(this);
        }

    }
    public void Healing(float healhPoints)
    {
        PlayerHealth += healhPoints;
        PlayerHealth = Mathf.Clamp(PlayerHealth, 0, 100);
        uiManger.UpdateHealthBar(PlayerHealth);
       

    }
    private void Laser()
    {
        // מיקום הלייזר יהיה זהה לשחקן
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Instantiate(LaserPrefab, pos, Quaternion.identity);
    }

}
