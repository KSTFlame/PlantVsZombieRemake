using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        if (state.YSummZone1.GetComponentInChildren<ThisCard>() != null && state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>() != null)
        {
            state.YSummZone1.GetComponentInChildren<ThisCard>().Hp -= state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>().Power;
            state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>().Hp -= state.YSummZone1.GetComponentInChildren<ThisCard>().Power;
        }
        else
            if (state.YSummZone1.GetComponentInChildren<ThisCard>() != null && state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>() == null)
            state.WinnerManager.GetComponent<NexusLifePoints>().enemyNexusHp -= state.YSummZone1.GetComponentInChildren<ThisCard>().Power;
        else
            if (state.YSummZone1.GetComponentInChildren<ThisCard>() == null && state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>() != null)
            state.WinnerManager.GetComponent<NexusLifePoints>().yourNexusHp -= state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>().Power;
        else
            Debug.Log("Entrambi Null");

        if (state.YSummZone1.GetComponentInChildren<ThisCard>() != null && state.YSummZone1.GetComponentInChildren<ThisCard>().Hp == 0)
            StateManager.Destroy(state.YSummZone1.GetComponentInChildren<ThisCard>().gameObject);
        if (state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>() != null && state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>().Hp == 0)
            StateManager.Destroy(state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>().gameObject);
        //Replicare questo codice per ogni casella di gioco, quindi altre 4 volte

        Exit(state);
    }

    public override void Exit(StateManager state)
    {
        if(state.Mana<10)
           state.Mana++;
        StateManager.currentMana = state.Mana;
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
