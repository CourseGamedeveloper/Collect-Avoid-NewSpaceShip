using UnityEngine;

/// <summary>
/// Base class for enemy behavior, including collision handling and damage.
/// </summary>
public class EnemyBase : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object.")]
    [SerializeField]
    private string triggeringTag;

    [Tooltip("The damage the enemy deals to the player.")]
    [SerializeField]
    private float damage;

    private Rigidbody2D rigidbody;

    /// <summary>
    /// Initializes the enemy's Rigidbody2D component.
    /// </summary>
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the enemy!");
        }
    }

    /// <summary>
    /// Handles collision events with other objects.
    /// </summary>
    /// <param name="collision">The collision data.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the specified triggering tag
        if (collision.collider.CompareTag(triggeringTag))
        {
            // Add score for hitting the enemy
            UIManager.AddScore(10);

            // Destroy the colliding object (e.g., a laser)
            Destroy(collision.gameObject);

            // Destroy this enemy
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Player"))
        {
            // Deal damage to the player
            collision.collider.GetComponent<PlayerController>().Take_Damage(damage);

            // Destroy this enemy after colliding with the player
            Destroy(gameObject);
        }
    }
}
