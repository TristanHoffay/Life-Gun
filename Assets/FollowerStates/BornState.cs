using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornState : IState
{
    [SerializeField]
    private float amazementTime = 5f + Time.time;
    private float lookAroundTime = Time.time + 0.5f;
    private Vector3 lookPosition;
    public void OnEnter(StateController controller)
    {
        // ensure proper facial animation
        controller.expressionController.SetAwe();
        lookPosition = controller.player.transform.position;
    }

    public void OnExit(StateController controller)
    {
        // undo any changes made for this state only that wont be updated
        
    }

    public void UpdateState(StateController controller)
    {
        // active AI 
        if (Time.time > amazementTime)
        {
            controller.ChangeState(controller.idleState);
        }
        if (Time.time > lookAroundTime)
        {
            // pick random direction to look at
            lookPosition = controller.transform.position +
                new Vector3(Random.Range(-20f, 20f),
                Random.Range(-10f, 10f), Random.Range(-20f, 20f));
            lookAroundTime = Time.time + Random.Range(0.1f, 1f);
        }
        // face player like idle
        Quaternion rotate = Quaternion.LookRotation(
            controller.transform.position - lookPosition,
            Vector3.up);

        Quaternion rotateLerp = Quaternion.Lerp(controller.GetComponent<Rigidbody>().rotation,
             rotate, Time.deltaTime * 10);
        if (Mathf.Abs(Quaternion.Angle(controller.GetComponent<Rigidbody>().rotation, rotate)) > 20f)
            controller.GetComponent<Rigidbody>().MoveRotation(rotateLerp);
    }
}
