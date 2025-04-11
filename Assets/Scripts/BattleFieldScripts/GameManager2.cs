using UnityEngine;
using TMPro; // Only needed if using TextMeshProUGUI
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public AudioClip music;
    public GameObject bossDefeatedText; // Assign the UI Text GameObject
    private AudioSource audioSource;
    private bool bossDefeated = false;
    private float floatSpeed = 2f;
    private float floatAmplitude = 20f;
    private Vector2 originalAnchoredPos;
    private RectTransform textRect;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && music != null)
        {
            audioSource.clip = music;
            audioSource.loop = true;
            audioSource.volume = 0.10f;
            audioSource.Play();
        }

        if (bossDefeatedText != null)
        {
            bossDefeatedText.SetActive(false);
            textRect = bossDefeatedText.GetComponent<RectTransform>();
            originalAnchoredPos = textRect.anchoredPosition;
        }
    }

    void Update()
    {
        if (!bossDefeated)
        {
            GameObject boss = GameObject.FindGameObjectWithTag("BossEnemy");
            if (boss == null) // Boss is gone
            {
                ShowBossDefeatedText();
            }
        }
        else if (textRect != null)
        {
            // Floating animation for UI text
            float offsetY = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
            textRect.anchoredPosition = originalAnchoredPos + new Vector2(0f, offsetY);
        }
    }

    void ShowBossDefeatedText()
    {
        bossDefeated = true;
        if (bossDefeatedText != null)
        {
            bossDefeatedText.SetActive(true);
            textRect = bossDefeatedText.GetComponent<RectTransform>();
            originalAnchoredPos = textRect.anchoredPosition;
        }
    }
}
