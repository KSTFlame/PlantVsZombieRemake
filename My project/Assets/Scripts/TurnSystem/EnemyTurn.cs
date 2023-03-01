using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class EnemyTurn : State
{
    public Button YourTurnButton;
    private StateManager saveState;

    public override void Enter(StateManager state)
    {
        Debug.Log("EnemyTurn");
        saveState = state;
        YourTurnButton = state.YourTurnButton;
        YourTurnButton.onClick.AddListener(TaskOnClick);
        StateManager.Instantiate(state.CardToHand, state.transform.position, state.transform.rotation);

        switch (state.Mana)
        {
            case 1:
                
                //StateManager.Instantiate(state.enemyCardPrefab, state.transform.position, state.transform.rotation);
                //state.ESummZone1 = GameObject.Find("ESummZone1");
                //state.enemyCardPrefab.transform.SetParent(state.ESummZone1.transform);
                /*state.enemyCardPrefab.transform.localScale = Vector3.one;
                state.enemyCardPrefab.transform.position = new Vector3(state.transform.position.x, state.transform.position.y, -48);
                state.enemyCardPrefab.transform.eulerAngles = new Vector3(25, 0, 0);*/
                break;
        }
    }

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
