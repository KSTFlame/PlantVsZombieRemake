using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTurn : State
{
    public Button YourTurnButton;
    private StateManager saveState;

    public override void Enter(StateManager state)
    {
        Debug.Log("EnemyTurn");
        saveState = state;
        YourTurnButton = state.YourTurnButton;
        YourTurnButton.onClick.AddListener(TaskOnClick);    }

    public override void Exit(StateManager state)
    {
        YourTurnButton.onClick.RemoveListener(TaskOnClick);
        state.ChangeState(state.YourState);
    }

    public override void StateUpdate(StateManager state)
    {
        //L'avversario piazza in campo le sue carte in un certo ordine e poi passa il turno
        
    }

    void TaskOnClick()
    {
        Exit(saveState);
    }
}
