using UnityEngine;

public class CanvasScroleer : MonoBehaviour
{
    public float floatSpeed = 20f; // Pixels per second if it's UI

    private RectTransform rectTransform;
    private Vector2 initialPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            initialPosition = rectTransform.anchoredPosition;
        }
    }

    void Update()
    {
        if (rectTransform != null)
        {
            // Move the canvas upward in local space (for UI)
            rectTransform.anchoredPosition += new Vector2(0, floatSpeed * Time.deltaTime);
        }
    }
}
