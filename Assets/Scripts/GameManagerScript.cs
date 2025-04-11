using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject Credits;
    //public GameObject BattleFeildUI;
    //public GameObject CareSceneUI;
    public GameObject CreditsUI;

    public void Awake()
    {
        MainMenuUI.SetActive(true);

    }



    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        MainMenuUI.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("CareScene");
        //CareSceneUI.SetActive(true);
        
    }

    public void BattleScene()
    {
        SceneManager.LoadScene("BattleField");
        //BattleFeildUI.SetActive(true);
    }
    public void CareScene()
    {
        SceneManager.LoadScene("CareScene");

        //CareSceneUI.SetActive(true);
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene("Credits");
        CreditsUI.SetActive(true);
    }
    public void OpenCreditsScene() //for buttons
    {
        SceneManager.LoadScene("Credits");
        CreditsUI.SetActive(true);
    }
    public void CloseCreditsScene()
    {
        SceneManager.LoadScene("MainMenu"); //for buttons
        CreditsUI.SetActive(true);
    }

}
