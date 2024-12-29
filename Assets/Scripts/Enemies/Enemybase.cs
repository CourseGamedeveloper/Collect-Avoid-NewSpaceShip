using UnityEngine;

public class Enemybase : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] 
    private string triggeringTag;

    [SerializeField]
    [Tooltip("the Damage Enemy Make")]
    private float damge=10f;

    private Rigidbody2D rigidbody;
    private void start()
    {
        rigidbody = GetComponent<Rigidbody2D> ();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the triggering tag
        if (collision.collider.CompareTag(triggeringTag))
        {
            UIManager.AddScore(10);
            Destroy(collision.gameObject); // Destroy the laser
            Destroy(gameObject); // Destroy the enemy
        }
        else if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.collider.GetComponent<PlayerController>().Take_Damge(damge);
        }
    }
   
}
