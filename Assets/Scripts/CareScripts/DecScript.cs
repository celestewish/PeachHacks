using UnityEngine;

public class DecScript : MonoBehaviour
{
    [Header("UI Canvas to Show")]
    public GameObject canvasToOpen;
    public AudioClip open;

    void OnMouseDown()
    {
        if (canvasToOpen != null)
        {
            AudioSource.PlayClipAtPoint(open, transform.position);
            canvasToOpen.SetActive(true);
            Debug.Log("Canvas opened from item click: " + gameObject.name);
        }
    }
}