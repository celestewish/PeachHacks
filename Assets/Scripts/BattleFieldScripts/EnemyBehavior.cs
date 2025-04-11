using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float bounceHeight = 0.5f;       // How high it bounces
    public float bounceSpeed = 2f;          // How fast it bounces

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = startPos + new Vector3(0f, newY, 0f);
    }
}
