using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public Vector3 target;
    [Range(0, 10)]
    public float movementSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        // If position is not target's position
        if (transform.position != target)
        {
            // Calculate distance from target
            float distanceFromTarget = Vector3.Distance(transform.position, target);
            // Calculate distance to travel this frame
            float distanceToTravel = movementSpeed * Time.deltaTime;
            // If distance to travel is less than distance from target, move to target's position,
            // else move towards it
            if (distanceToTravel >= distanceFromTarget) {
                transform.position = target;
            }
            else
            {
                Vector3 velocity = (target - transform.position).normalized * distanceToTravel;
                gameObject.transform.Translate(velocity);
            }
        }

        
    }
}
