using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How much healing for the player when they take the heart")]
    private float PointHealing = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.collider.GetComponent<PlayerController>().Healing(PointHealing);
        }
    }
}
