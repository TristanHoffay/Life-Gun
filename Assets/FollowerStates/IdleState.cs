using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private float expressionTimer = 2f;
    public void OnEnter(StateController controller)
    {
        // ensure proper facial animation
        controller.expressionController.SetCute();
        // initialize time before expression changes
        expressionTimer = Time.time + Random.Range(0.5f, 10f);
    }

    public void OnExit(StateController controller)
    {
        // undo any changes made for this state only that wont be updated
    }

    public void UpdateState(StateController controller)
    {
        // active AI 
        // if player moves far enough, switch to follow state
        if (Vector3.Distance(controller.player.transform.position, controller.transform.position) > 10)
            controller.ChangeState(controller.followState);
        // if player moves too close, back up a bit
        if (Vector3.Distance(controller.player.transform.position, controller.transform.position) < 3)
            controller.ChangeState(controller.followState);

        // become upright and look at player
        //also rotate toward player
        Quaternion rotate =  Quaternion.LookRotation(
            controller.transform.position - controller.player.transform.position,
            Vector3.up);

        Quaternion rotateLerp = Quaternion.Lerp(controller.GetComponent<Rigidbody>().rotation,
             rotate, Time.deltaTime * 2);
        if (Mathf.Abs(Quaternion.Angle(controller.GetComponent<Rigidbody>().rotation, rotate)) > 20f)
            controller.GetComponent<Rigidbody>().MoveRotation(rotateLerp);

        // cycle through idle expressions at random
        if (expressionTimer < Time.time)
        {
            //cycle between shocked or digruntled emotions
            float r = Random.Range(0, 3);
            if (r < 1)
                controller.expressionController.SetCute();
            else if (r < 2)
                controller.expressionController.SetPleased();
            else
                controller.expressionController.SetHappy();
            // set new time for expression change
            expressionTimer = Time.time + Random.Range(0.5f, 10f);
        }
    }
}
