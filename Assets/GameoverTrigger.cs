using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public GameOverScreen gameOverScreen; // Reference to the GameOverScreen script
    public Transform towerBase; // The transform of the tower's base or initial position
    public float towerBaseRadius = 5f; // The radius defining the acceptable boundary around the tower base
    public Transform towerTop; // The topmost block of the tower to monitor its stability
    public float maxAllowedTiltAngle = 20f; // The maximum tilt angle allowed before triggering game over

    void Update()
    {
        // Check if the tower has toppled
        CheckTowerStability();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the block collides outside the tower base
        if (collision.gameObject.CompareTag("Block"))
        {
            Vector3 blockPosition = collision.transform.position;
            if (IsOutsideTowerBase(blockPosition))
            {
                TriggerGameOver();
            }
        }
    }

    bool IsOutsideTowerBase(Vector3 position)
    {
        // Calculate the distance from the block position to the tower base center
        float distanceToBase = Vector3.Distance(new Vector3(position.x, towerBase.position.y, position.z), towerBase.position);
        return distanceToBase > towerBaseRadius;
    }

    void CheckTowerStability()
    {
        // Check if the tower's top is tilted beyond the maximum allowed angle
        float currentTiltAngle = Vector3.Angle(Vector3.up, towerTop.up);
        if (currentTiltAngle > maxAllowedTiltAngle)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        // Trigger the game over state
        gameOverScreen.TriggerGameOver();
    }
}