using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<GameStateMachine>();
    }
}
