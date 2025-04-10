using UnityEngine;

public class PetController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRange = 1.5f;
    public float attackRate = 1f;
    public int attackDamage = 10;

    private Vector3 targetPosition;
    private GameObject currentTargetEnemy;
    private float attackCooldown = 0f;

    private bool isAttacking = false;

    void Update()
    {
        HandleInput();
        MoveToTarget();

        if (currentTargetEnemy != null)
        {
            float distance = Vector2.Distance(transform.position, currentTargetEnemy.transform.position);
            if (distance <= attackRange)
            {
                isAttacking = true;
                AttackEnemy();
            }
            else
            {
                isAttacking = false;
            }

            // Stop targeting if the enemy is destroyed
            if (currentTargetEnemy == null)
            {
                isAttacking = false;
            }
        }

        attackCooldown -= Time.deltaTime;
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                currentTargetEnemy = hit.collider.gameObject;
                targetPosition = currentTargetEnemy.transform.position;
            }
            else
            {
                currentTargetEnemy = null;
                isAttacking = false;
                targetPosition = mousePos;
            }
        }
    }

    void MoveToTarget()
    {
        if (currentTargetEnemy != null && isAttacking)
            return; // Don't move if attacking

        if ((transform.position - targetPosition).sqrMagnitude > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void AttackEnemy()
    {
        if (attackCooldown <= 0f && currentTargetEnemy != null)
        {
            // Assuming enemy has a script with TakeDamage(int amount) and a health system
            EnemyHealth enemyHealth = currentTargetEnemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);

                if (enemyHealth.currentHealth <= 0)
                {
                    currentTargetEnemy = null;
                    isAttacking = false;
                }
            }

            attackCooldown = 1f / attackRate;
        }
    }
}
