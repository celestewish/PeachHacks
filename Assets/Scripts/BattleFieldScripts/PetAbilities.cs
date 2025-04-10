using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PetAbilities : MonoBehaviour
{
    [Header("Ability Prefabs & Settings")]
    public GameObject lineFireEffect;
    public GameObject ultimateExplosionEffect;
    public float lineFireRange = 10f;
    public float ultimateRadius = 5f;

    [Header("Cooldown Settings")]
    public float baseCooldown = 10f;
    public float ultCooldown = 60f;
    private float baseCooldownTimer = 0f;
    private float ultCooldownTimer = 0f;

    [Header("UI Elements")]
    public Image baseAbilityOverlay;
    public TextMeshProUGUI baseAbilityText;
    public Image ultAbilityOverlay;
    public TextMeshProUGUI ultAbilityText;

    [Header("Misc")]
    public LayerMask enemyLayers;
    public Camera mainCam;
    public float screenShakeDuration = 0.3f;
    public float screenShakeMagnitude = 0.2f;

    void Update()
    {
        HandleCooldowns();

        if (Input.GetKeyDown(KeyCode.Alpha1) && baseCooldownTimer <= 0f)
        {
            UseLineFire();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ultCooldownTimer <= 0f && AreAllEnemiesDead())
        {
            StartCoroutine(UseUltimate());
        }

        UpdateUI();
    }

    GameObject GetTargetEnemy()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }


    void UseLineFire()
    {
        GameObject target = GetTargetEnemy();
        if (target == null) return;

        Vector2 direction = (target.transform.position - transform.position).normalized;
        Vector2 origin = transform.position;

        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction, lineFireRange, enemyLayers);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                EnemyHealth eh = hit.collider.GetComponent<EnemyHealth>();
                if (eh != null) eh.TakeDamage(50);
            }
        }

        if (lineFireEffect)
        {
            GameObject fire = Instantiate(lineFireEffect, origin, Quaternion.LookRotation(Vector3.forward, direction));
            Destroy(fire, 3);
        }

        baseCooldownTimer = baseCooldown;
    }


    IEnumerator UseUltimate()
    {
        GameObject target = GetTargetEnemy();
        if (target == null) yield break;

        Vector3 pos = target.transform.position;

        Collider2D[] hits = Physics2D.OverlapCircleAll(pos, ultimateRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy") || hit.CompareTag("BossEnemy"))
            {
                EnemyHealth eh = hit.GetComponent<EnemyHealth>();
                if (eh != null) eh.TakeDamage(500);
            }
        }

        if (ultimateExplosionEffect)
        {
            GameObject fire = Instantiate(ultimateExplosionEffect, pos, Quaternion.identity);
            Destroy(fire, 3);
        }

        StartCoroutine(ShakeCamera(screenShakeDuration, screenShakeMagnitude));

        ultCooldownTimer = ultCooldown;
        yield return null;
    }


    void HandleCooldowns()
    {
        if (baseCooldownTimer > 0)
            baseCooldownTimer -= Time.deltaTime;

        if (ultCooldownTimer > 0)
            ultCooldownTimer -= Time.deltaTime;
    }

    void UpdateUI()
    {
        if (baseAbilityOverlay)
        {
            baseAbilityOverlay.fillAmount = baseCooldownTimer / baseCooldown;
            baseAbilityText.text = baseCooldownTimer > 0 ? Mathf.Ceil(baseCooldownTimer).ToString() : "";
        }

        if (ultAbilityOverlay)
        {
            ultAbilityOverlay.fillAmount = ultCooldownTimer / ultCooldown;
            ultAbilityText.text = ultCooldownTimer > 0 ? Mathf.Ceil(ultCooldownTimer).ToString() : "";
        }
    }

    bool AreAllEnemiesDead()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length == 0;
    }

    IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPos = mainCam.transform.position;

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            mainCam.transform.position = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        mainCam.transform.position = originalPos;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ultimateRadius);
    }
}
