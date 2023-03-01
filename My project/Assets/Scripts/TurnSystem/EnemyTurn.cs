using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class EnemyTurn : State
{
    public Button YourTurnButton;
    private StateManager saveState;
    private int c = 0;

    public override void Enter(StateManager state)
    {
        Debug.Log("EnemyTurn");
        saveState = state;
        YourTurnButton = state.YourTurnButton;
        YourTurnButton.onClick.AddListener(TaskOnClick);
        if (c < 14)
        {
            StateManager.Instantiate(state.CardToHand, state.transform.position, state.transform.rotation);
            c++;
        }

        switch (state.Mana)
        {
            case 2:
                Debug.Log("Turno Nemico 2: Setuppa una sua carta");
                GameObject enemyCardPrefab = StateManager.Instantiate(state.enemyCardPrefab, state.ESummZone1.transform.position, state.ESummZone1.transform.rotation);
                enemyCardPrefab.transform.SetParent(state.ESummZone1.transform);
                break;
            case 3:
                GameObject enemyCardPrefab2 = StateManager.Instantiate(state.enemyCardPrefab, state.ESummZone2.transform.position, state.ESummZone2.transform.rotation);
                Debug.Log("Turno Nemico 3: Setuppa un'altra carta");
                enemyCardPrefab2.transform.SetParent(state.ESummZone2.transform);
                break;
            /*case 4:
                Debug.Log("Turno Nemico 3: Setuppa un'altra carta");
                enemyCardPrefab.transform.SetParent(state.ESummZone2.transform);
                enemyCardPrefab.transform.SetParent(state.ESummZone1.transform);
                break;*/
            default: break;
        }

        Exit(state);
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
