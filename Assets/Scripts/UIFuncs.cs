using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFuncs : MonoBehaviour
{
    public void UIEnable(GameObject objectToEnable)
    {
        objectToEnable.SetActive(true);
    }

    public void UIDisable(GameObject objectToDisable)
    {
        objectToDisable.SetActive(false);
    }

    public void LoadScene(string sceneNameString)
    {
        SceneManager.LoadScene(sceneNameString, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeGameMode(int mode)
    {
        Globals.gameMode = (GameMode)mode;
    }

    public void ChangeScoreToWin(string inputScore)
    {
        Globals.scoreToWin = Convert.ToUInt16(inputScore);
    }

    public void InputFieldActivate(InputField inputField)
    {
        inputField.ActivateInputField();
    }
}
