using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Still needed for the Button component

public class DecCanvas : MonoBehaviour
{
    [Header("Buttons")]
    public Button buttonOne;
    public Button buttonTwo;

    [Header("Scene Settings")]
    public string nextSceneName;

    void Start()
    {
        if (buttonOne != null)
            buttonOne.onClick.AddListener(LoadNextScene);

        if (buttonTwo != null)
            buttonTwo.onClick.AddListener(LoadNextScene);
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Scene name not set in CanvasButtonSceneLoader!");
        }
    }
}