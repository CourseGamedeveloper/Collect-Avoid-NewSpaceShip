using UnityEngine;

/// <summary>
/// Manages the spawning of objects (e.g., enemies) at random intervals.
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The prefab to spawn (e.g., an enemy or collectible).")]
    private GameObject prefab;

    [SerializeField]
    [Tooltip("The minimum time interval between spawns.")]
    private float minimumSpawnTime;

    [SerializeField]
    [Tooltip("The maximum time interval between spawns.")]
    private float maximumSpawnTime;

    private float timeUntilSpawn; // Time left until the next spawn

    /// <summary>
    /// Initializes the spawn timer.
    /// </summary>
    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    /// <summary>
    /// Updates the spawn timer and spawns the object when the timer reaches zero.
    /// </summary>
    private void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            // Spawn the object
            Instantiate(prefab, transform.position, Quaternion.identity);

            // Reset the timer for the next spawn
            SetTimeUntilSpawn();
        }
    }

    /// <summary>
    /// Sets a random time interval for the next spawn, between the minimum and maximum spawn times.
    /// </summary>
    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
