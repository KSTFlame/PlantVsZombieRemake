using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YourTurn : State
{
    public Button EndTurnButton;
    private StateManager saveState;

    public override void Enter(StateManager state)
    {
        Debug.Log("MyTurn");
        saveState = state;
        EndTurnButton = state.EndTurnButton;
        EndTurnButton.onClick.AddListener(TaskOnClick);
    }

    public override void Exit(StateManager state)
    {
        EndTurnButton.onClick.RemoveListener(TaskOnClick);
        state.ChangeState(state.BattleState);
    }

    public override void StateUpdate(StateManager state)
    {
        
    }

    void TaskOnClick()
    {
        Exit(saveState);
    }
}
