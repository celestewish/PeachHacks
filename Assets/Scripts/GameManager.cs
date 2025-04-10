using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Activation Settings")]
    public GameObject objectToActivate;

    private bool hasActivated = false;

    void Update()
    {
        if (hasActivated) return;

        // Check if there are any objects with tag "Food" or "Brush" left
        GameObject[] foodItems = GameObject.FindGameObjectsWithTag("Food");
        GameObject[] brushItems = GameObject.FindGameObjectsWithTag("Brush");

        if (foodItems.Length == 0 && brushItems.Length == 0)
        {
            ActivateNextObject();
        }
    }

    void ActivateNextObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
            Debug.Log("All items gone! Activating next object.");
        }
        hasActivated = true;
    }
}