using Fusion;
using UnityEngine;

/// <summary>
/// Handles the behavior of the laser projectile.
/// </summary>
public class Laser : NetworkBehaviour
{
    [SerializeField]
    private float lifetime;

    private float spawnTime;

    public override void Spawned()
    {
        spawnTime = Time.time; // Record the time when the laser is spawned.
    }

    public override void FixedUpdateNetwork()
    {
        // Move the laser upward based on the speed constant.
        float movementSpeed = Constants.Laser_speed * Runner.DeltaTime;
        transform.Translate(Vector3.up * movementSpeed);

        // Check if the laser's lifetime has expired or is out of bounds.
        if (Time.time - spawnTime >= lifetime || !IsInBounds())
        {
            Runner.Despawn(Object);
        }
    }

    /// <summary>
    /// Checks if the laser is still within the screen bounds.
    /// </summary>
    /// <returns>True if the laser is within bounds; otherwise, false.</returns>
    private bool IsInBounds()
    {
        // Convert the laser's position to viewport coordinates to check screen boundaries.
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }
}
