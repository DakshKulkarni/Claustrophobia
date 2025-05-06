using UnityEngine;

public class DynamicRocksNarrowing : MonoBehaviour
{
    public Transform player; // Reference to the XR Origin or Camera
    public Transform[] rocks; // Array of all the rocks
    public float moveSpeed = 1f; // Speed at which rocks move inward
    public float minDistanceFromPlayer = 1.5f; // Minimum distance rocks should maintain from player
    public float triggerDistance = 2f; // Distance along Z-axis for triggering movement

    private Vector3[] originalPositions; // Store original positions of rocks

    void Start()
    {
        // Store the original positions of all rocks
        originalPositions = new Vector3[rocks.Length];
        for (int i = 0; i < rocks.Length; i++)
        {
            originalPositions[i] = rocks[i].position;
        }
    }

    void Update()
    {
        if (IsPlayerInTriggerZone())
        {
            MoveRocksTowardsPlayer();
        }
        else
        {
            ResetRocksToOriginalPositions();
        }
    }

    private bool IsPlayerInTriggerZone()
    {
        foreach (Transform rock in rocks)
        {
            if (Mathf.Abs(player.position.x - rock.position.x) <= triggerDistance) // Trigger check on X-axis
            {
                return true;
            }
        }
        return false;
    }

    private void MoveRocksTowardsPlayer()
    {
        foreach (Transform rock in rocks)
        {
            float step = moveSpeed * Time.deltaTime;
            float targetZ = player.position.z; // Move towards player's Z position

            // Ensure the rock does not get too close to the player
            if (rock.position.z < player.position.z - minDistanceFromPlayer)
            {
                rock.position = Vector3.MoveTowards(rock.position, new Vector3(rock.position.x, rock.position.y, targetZ - minDistanceFromPlayer), step);
            }
            else if (rock.position.z > player.position.z + minDistanceFromPlayer)
            {
                rock.position = Vector3.MoveTowards(rock.position, new Vector3(rock.position.x, rock.position.y, targetZ + minDistanceFromPlayer), step);
            }
        }
    }

    private void ResetRocksToOriginalPositions()
    {
        for (int i = 0; i < rocks.Length; i++)
        {
            float step = moveSpeed * Time.deltaTime;
            rocks[i].position = Vector3.MoveTowards(rocks[i].position, originalPositions[i], step);
        }
    }
}
