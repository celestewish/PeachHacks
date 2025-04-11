
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject Credits;
    public GameObject BattleFeildUI;
    public GameObject CareSceneUI;

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
        SceneManager.LoadScene("Level1");
        MainMenuUI.SetActive(true);

    }

    public void BattleScene()
    {
        SceneManager.LoadScene("BattleFeild");
        BattleFeildUI.SetActive(true);
    }
    public void CareScene()
    {
        SceneManager.LoadScene("CareScene");
        CareSceneUI.SetActive(true);
    }
}
