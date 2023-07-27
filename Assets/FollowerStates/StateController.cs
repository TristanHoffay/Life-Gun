using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public ExpressionController expressionController;
    public GameObject player;

    IState currentState;
    public FollowState followState = new FollowState();
    public IdleState idleState = new IdleState();
    public MoveCommandState moveCommandState = new MoveCommandState();
    public AttackState attackState = new AttackState();
    void Start()
    {
        expressionController = GetComponent<ExpressionController>();
        player = GameObject.FindWithTag("Player").GetComponentInChildren<Camera>().gameObject;
        ChangeState(new BornState());
    }
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        currentState.OnEnter(this);
    }
}
public interface IState
{
    public void OnEnter(StateController controller);
    public void UpdateState(StateController controller);
    public void OnExit(StateController controller);
}
