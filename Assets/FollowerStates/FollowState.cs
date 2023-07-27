using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : IState
{
    private float expressionTimer = 2f;
    public void OnEnter(StateController controller)
    {
        // ensure proper facial animation
        controller.expressionController.SetCurious();
        // initialize time before expression changes
        expressionTimer = Time.time + Random.Range(0.5f, 10f);
    }

    public void OnExit(StateController controller)
    {
        // undo any changes made for this state only that wont be updated
        controller.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void UpdateState(StateController controller)
    {
        // active AI 

        // if close enough to player, switch to idle
        if (Vector3.Distance(controller.player.transform.position, controller.transform.position) < 7)
        {
            // if too close, move back
            if (Vector3.Distance(controller.player.transform.position, controller.transform.position) < 5)
            {
                // move toward player
                controller.GetComponent<Rigidbody>().velocity =
                    // new direction velocity
                    (new Vector3(
                    controller.player.transform.position.x - controller.transform.position.x,
                    0,
                    controller.player.transform.position.z - controller.transform.position.z)
                    .normalized
                    * -5f)
                    // plus original Y velocity
                    + new Vector3(0, controller.GetComponent<Rigidbody>().velocity.y, 0);
                //check for expression change
                if (expressionTimer < Time.time)
                {
                    //cycle between shocked or digruntled emotions
                    float r = Random.Range(0, 3);
                    if (r < 1)
                        controller.expressionController.SetShocked();
                    else if (r < 2)
                        controller.expressionController.SetFrown();
                    else
                        controller.expressionController.SetCuteAngry();
                    // set new time for expression change
                    expressionTimer = Time.time + Random.Range(0.5f, 10f);
                }
            }
            else
                controller.ChangeState(controller.idleState);
        }
        // move toward player
        else
        {
            controller.GetComponent<Rigidbody>().velocity =
                // new direction velocity
                (new Vector3(
                controller.player.transform.position.x - controller.transform.position.x,
                0,
                controller.player.transform.position.z - controller.transform.position.z)
                / 5f)
                // plus original Y velocity
                + new Vector3(0, controller.GetComponent<Rigidbody>().velocity.y - (9.8f * Time.deltaTime), 0);
            /*controller.GetComponent<Rigidbody>().velocity +=
                // new direction velocity
                (new Vector3(
                controller.player.transform.position.x - controller.transform.position.x,
                0,
                controller.player.transform.position.z - controller.transform.position.z)
                * Time.deltaTime * 10f);*/
            //check for expression change
            if (expressionTimer < Time.time)
            {
                //cycle between shocked or digruntled emotions
                float r = Random.Range(0, 3);
                if (r < 1)
                    controller.expressionController.SetCurious();
                else if (r < 2)
                    controller.expressionController.SetHappy();
                else
                    controller.expressionController.SetWhistling();
                // set new time for expression change
                expressionTimer = Time.time + Random.Range(0.5f, 10f);
            }
        }
        
    }
}
