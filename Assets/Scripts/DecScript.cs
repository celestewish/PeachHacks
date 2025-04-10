using UnityEngine;

public class DecScript : MonoBehaviour
{
    [Header("UI Canvas to Show")]
    public GameObject canvasToOpen;

    void OnMouseDown()
    {
        if (canvasToOpen != null)
        {
            canvasToOpen.SetActive(true);
            Debug.Log("Canvas opened from item click: " + gameObject.name);
        }
    }
}