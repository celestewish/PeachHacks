using UnityEngine;

public class PetIdleRoam : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 1f;
    public float roamRadius = 3f;
    public float waitTime = 2f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private float waitCounter;

    void Start()
    {
        startPosition = transform.position;
        ChooseNewTarget();
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
            {
                isMoving = false;
                waitCounter = waitTime;
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
        // Pick a random point in the roam radius
        Vector2 randomDirection = Random.insideUnitCircle * roamRadius;
        targetPosition = startPosition + new Vector3(randomDirection.x, randomDirection.y, 0f);
        isMoving = true;
    }
}