using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommandState : IState
{
    public void OnEnter(StateController controller)
    {
        // ensure proper facial animation
    }

    public void OnExit(StateController controller)
    {
        // undo any changes made for this state only that wont be updated
    }

    public void UpdateState(StateController controller)
    {
        // active AI 
    }
}
