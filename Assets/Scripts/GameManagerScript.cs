using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject MainMenuUI;
    //public GameObject Credits;
    //public GameObject BattleFeildUI;
    //public GameObject CareSceneUI;
    

    public void Awake()
    {
        MainMenuUI.SetActive(true);

    }



    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //MainMenuUI.SetActive(true);
    }

    public void StartGame()
    {
        CareScene();
        
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
        //Credits.SetActive(true);
    }
    public void OpenCreditsScene() //for buttons
    {
        CreditsScene();
    }
    public void CloseCreditsScene()
    {
        MainMenu(); //for buttons
        //Credits.SetActive(false);
       
    }

}
