using UnityEngine;

public class GenericStateMachine : MonoBehaviour
{
    protected GenericState currentState;

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    public void ChangeState(GenericState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual GenericState GetInitialState()
    {
        return null;
    }
}