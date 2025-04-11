using UnityEngine;

public class PetIdleRoam : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 1f;
    public float roamRadius = 3f;
    public float waitTime = 2f;

    [Header("Bounce Settings")]
    public float bounceHeight = 0.1f;
    public float bounceSpeed = 5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private float waitCounter;

    private float baseY; // Original Y position for bouncing

    void Start()
    {
        startPosition = transform.position;
        baseY = transform.position.y;
        ChooseNewTarget();
    }

    void Update()
    {
        if (isMoving)
        {
            // Move to target
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Add bounce effect while moving
            float bounce = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
            transform.position = new Vector3(transform.position.x, baseY + bounce, transform.position.z);

            // Stop moving if close enough
            if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
            {
                isMoving = false;
                waitCounter = waitTime;
                transform.position = new Vector3(transform.position.x, baseY, transform.position.z); // Reset Y
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            if (waitCounter <= 0f)
            {
                ChooseNewTarget();
            }
        }
    }

    void ChooseNewTarget()
    {
        Vector2 randomDirection = Random.insideUnitCircle * roamRadius;
        targetPosition = startPosition + new Vector3(randomDirection.x, randomDirection.y, 0f);
        baseY = transform.position.y; // Set baseY to new path
        isMoving = true;
    }
}
