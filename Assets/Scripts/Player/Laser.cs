using UnityEngine;

/// <summary>
/// Handles the behavior of the laser projectile.
/// </summary>
public class Laser : MonoBehaviour
{
    private void Update()
    {
        // Move the laser upward based on the speed constant.
        float movementSpeed = Constants.Laser_speed * Time.deltaTime;
        transform.Translate(Vector3.up * movementSpeed);

        // Check if the laser is out of bounds and deactivate it if true.
        if (!IsInBounds())
        {
            Deactivate();
        }
    }

    /// <summary>
    /// Deactivates the laser object.
    /// </summary>
    private void Deactivate()
    {
        gameObject.SetActive(false);
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
