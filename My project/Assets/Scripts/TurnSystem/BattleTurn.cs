using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTurn : State
{
    public Button EnemyTurnButton;
    private StateManager saveState;

    public override void Enter(StateManager state)
    {
        Debug.Log("BattleState");
        saveState = state;
        EnemyTurnButton = state.EnemyTurnButton;
        EnemyTurnButton.onClick.AddListener(TaskOnClick);
    }

    public override void Exit(StateManager state)
    {
        state.Mana++;
        StateManager.staticMana = state.Mana;
        EnemyTurnButton.onClick.RemoveListener(TaskOnClick);
        state.YourManaText.text = "/ Your Mana: " + state.Mana;
        state.EnemyManaText.text = "/ Enemy Mana: " + state.Mana;
        state.ChangeState(state.EnemyState);
    }

    public override void StateUpdate(StateManager state)
    {

    }
    void TaskOnClick()
    {
        Exit(saveState);
    }
}
