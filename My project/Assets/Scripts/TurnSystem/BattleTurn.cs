using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleTurn : State
{
    public Button EnemyTurnButton;
    private StateManager saveState;
    private int yourShield;
    private int enemyShield;
    

    public override void Enter(StateManager state)
    {
        Debug.Log("BattleState");
        saveState = state;
        EnemyTurnButton = state.EnemyTurnButton;
        EnemyTurnButton.onClick.AddListener(TaskOnClick);

        int rYour;
        int rEnemy;
        System.Random random = new System.Random();
        rYour = random.Next(1,100);
        rEnemy = random.Next(1,100);

        if (rYour > 0 && rYour <= 10)
            yourShield = 15;
        else if (rYour > 10 && rYour <= 65)
            yourShield = 30;
        else if (rYour > 65 && rYour <= 95)
            yourShield = 50;
        else
            yourShield = 100;

        if (rEnemy > 0 && rEnemy <= 10)
            enemyShield = 15;
        else if (rEnemy > 10 && rEnemy <= 65)
            enemyShield = 30;
        else if (rEnemy > 65 && rEnemy <= 95)
            enemyShield = 50;
        else
            enemyShield = 100;

        if (state.YSummZone1.GetComponentInChildren<ThisCard>() != null && state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>() != null)
        {
            state.YSummZone1.GetComponentInChildren<ThisCard>().totalHp -= state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>().Power;
            state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>().Hp -= state.YSummZone1.GetComponentInChildren<ThisCard>().Power;
        }
        else if (state.YSummZone1.GetComponentInChildren<ThisCard>() != null && state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>() == null)
        {
            state.EnemyShield += enemyShield;
            if(state.EnemyShield<100)
                state.WinnerManager.GetComponent<NexusLifePoints>().enemyNexusHp -= state.YSummZone1.GetComponentInChildren<ThisCard>().Power;
            else
                state.EnemyShield = 0;
        }
        else if (state.YSummZone1.GetComponentInChildren<ThisCard>() == null && state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>() != null)
        {
            state.YourShield += yourShield;
            if(state.YourShield<100)
                state.WinnerManager.GetComponent<NexusLifePoints>().yourNexusHp -= state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>().Power;
            else
                state.YourShield = 0;
        }
        else
            Debug.Log("Entrambi Null");

        if (state.YSummZone1.GetComponentInChildren<ThisCard>() != null && state.YSummZone1.GetComponentInChildren<ThisCard>().totalHp <= 0)
            StateManager.Destroy(state.YSummZone1.GetComponentInChildren<ThisCard>().gameObject);
        if (state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>() != null && state.ESummZone1.GetComponentInChildren<EnemyCardPlayed>().Hp <= 0)
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
        state.enemyShieldText.text = "Enemy shield: " + state.EnemyShield;
        state.YourShieldText.text = "Your shield: " + state.YourShield;
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
