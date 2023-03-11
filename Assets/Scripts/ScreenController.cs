using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    #region GAMEOBJECT_REFERENCES

    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _gameScreen;

    #endregion

    #region EVENTS

    private static Action<bool> OnToggleMenuScreen;

    public static void RaiseOnToggleMenuScreen(bool showScreen)
    {
        OnToggleMenuScreen?.Invoke(showScreen);
    }
    
    private static Action<bool> OnToggleGameScreen;

    public static void RaiseOnToggleGameScreen(bool showScreen)
    {
        OnToggleGameScreen?.Invoke(showScreen);
    }

    #endregion

    private void Awake()
    {
        OnToggleMenuScreen += ToggleMenuScreen;
        OnToggleGameScreen += ToggleGameScreen;
    }

    private void ToggleGameScreen(bool showScreen)
    {
        _gameScreen.SetActive(showScreen);
    }

    private void ToggleMenuScreen(bool showScreen)
    {
        _menuScreen.SetActive(showScreen);
    }

    private void OnDestroy()
    {
        OnToggleMenuScreen -= ToggleMenuScreen;
        OnToggleGameScreen -= ToggleGameScreen;
    }
}
