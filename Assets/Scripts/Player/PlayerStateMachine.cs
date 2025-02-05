using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState currentState {  get; private set; }   


    public void Initialize(PlayerState _playerState)
    {
        currentState = _playerState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
