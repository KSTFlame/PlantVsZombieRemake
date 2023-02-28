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

    public int Mana;
    public static int staticMana;
    public Text YourManaText;
    public Text EnemyManaText;

    public void Start()
    {
        Mana = 0;
        staticMana= Mana;
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