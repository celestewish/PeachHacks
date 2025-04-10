using UnityEngine;

public class Ability1Script : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 50;
    private Vector2 moveDirection;

    public void SetDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth eh = other.GetComponent<EnemyHealth>();
            if (eh != null)
            {
                eh.TakeDamage(damage);
            }

            Destroy(gameObject, 5);
        }
    }
}