using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    #region REFERENCES

    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private GameScreen _gameScreen;

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
        _gameScreen.gameObject.SetActive(showScreen);
        if (showScreen)
        {
            _gameScreen.InitializeScreen();
        }
    }

    private void ToggleMenuScreen(bool showScreen)
    {
        _menuScreen.gameObject.SetActive(showScreen);
        _menuScreen.Initialize();
    }

    private void OnDestroy()
    {
        OnToggleMenuScreen -= ToggleMenuScreen;
        OnToggleGameScreen -= ToggleGameScreen;
    }
}
