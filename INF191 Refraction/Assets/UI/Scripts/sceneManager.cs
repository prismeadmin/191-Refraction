﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public int PortraitWidth;
    public int PortraitHeight;
    public int LandscapeWidth;
    public int LandscapeHeight;

    public void SetPortrait()
    {
        Screen.SetResolution(PortraitWidth, PortraitHeight, false);
    }

    public void SetLandscape()
    {
        Screen.SetResolution(LandscapeWidth, LandscapeHeight, false);
    }

    public void LoadLoginStage()
    {
        Screen.SetResolution(PortraitWidth, PortraitHeight, false);
        SceneManager.LoadScene(0);
    }

    public void LoadAccountSetupStage()
    {
        Screen.SetResolution(PortraitWidth, PortraitHeight, false);
        SceneManager.LoadScene(1);
    }

    public void LoadQuiz()
    {
        Screen.SetResolution(PortraitWidth, PortraitHeight, false);
        SceneManager.LoadScene(2);
    }
    
    public void LoadMainGameStage()
    {
        Screen.SetResolution(LandscapeWidth, LandscapeHeight, false);
        SceneManager.LoadScene(3);
    }

    public void LoadZerOne()
    {
        Screen.SetResolution(LandscapeWidth, LandscapeHeight, false);
        SceneManager.LoadScene(4);
    }
    
    public void LoadConnect4()
    {
        Screen.SetResolution(LandscapeWidth, LandscapeHeight, false);
        SceneManager.LoadScene(5);
    }

    public void LoadInterviewPortal()
    {
        Screen.SetResolution(LandscapeWidth, LandscapeHeight, false);
        SceneManager.LoadScene(6);
    }

    
}
