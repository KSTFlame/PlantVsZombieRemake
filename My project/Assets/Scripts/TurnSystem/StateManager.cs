using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public EnemyTurn EnemyState = new EnemyTurn();
    public YourTurn YourState = new YourTurn();
    public BattleTurn BattleState = new BattleTurn();

    public Button EnemyTurnButton;
    public Button YourTurnButton;
    public Button EndTurnButton;

    public GameObject CardToHand;

    public int Mana;
    public int YourHp;
    public int EnemyHp;
    public static int currentMana;
    public Text YourManaText;
    public Text EnemyManaText;

    public GameObject WinnerManager;
    public GameObject YSummZone1;

    public GameObject ESummZone1;
    public GameObject enemyCardPrefab;
    public List<GameObject> enemyCardHand; 

    public void Start()
    {
        Mana = 1;
        currentMana = Mana;
        YourHp = 20;
        EnemyHp = 20;
        YourManaText.text = "/ Your Mana: " + Mana;
        EnemyManaText.text = "/ Enemy Mana: " + Mana;
        currentState = EnemyState;
        currentState.Enter(this);

    }

    private void Update()
    {
        currentState.StateUpdate(this);
    }

    public void ChangeState(State state)
    {
        currentState = state;
        state.Enter(this);
    }
}

public abstract class State
{
    public string stateID;

    public State() { }

    public abstract void Enter(StateManager state);

    public abstract void StateUpdate(StateManager state);

    public abstract void Exit(StateManager state);
}