using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class RabbitAgent : Agent
{
    [Tooltip("How fast the agent moves forward")]
    public float moveSpeed = 5f;

    [Tooltip("How fast the agent turns")]
    public float turnSpeed = 180f;

    private GrasslandArea grasslandArea;
    new private Rigidbody rigidbody;
    private GameObject bush;
    private bool isFull;

    public override void Initialize()
    {
        base.Initialize();
        grasslandArea = GetComponentInParent<GrasslandArea>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Convert the first action to forward movement
        float forwardAmount = actionBuffers.DiscreteActions[0];

        // Convert the second action to turning left or right
        float turnAmount = 0f;
        if (actionBuffers.DiscreteActions[1] == 1f)
        {
            turnAmount = -1f;
        }
        else if (actionBuffers.DiscreteActions[1] == 2f)
        {
            turnAmount = 1f;
        }

        // Apply movement
        rigidbody.MovePosition(transform.position + transform.forward * forwardAmount * moveSpeed * Time.fixedDeltaTime);
        transform.Rotate(transform.up * turnAmount * turnSpeed * Time.fixedDeltaTime);

        if (MaxStep > 0) AddReward(-1f / MaxStep);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        int forwardAction = 0;
        int turnAction = 0;
        if (Input.GetKey(KeyCode.W))
        {
            // move forward
            forwardAction = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // turn left
            turnAction = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // turn right
            turnAction = 2;
        }

        // Put the actions into the array
        actionsOut.DiscreteActions.Array[0] = forwardAction;
        actionsOut.DiscreteActions.Array[1] = turnAction;
    }

    //This is what controls what happens at the start of every episode
    public override void OnEpisodeBegin()
    {
        isFull = false;
        grasslandArea.ResetArea();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(isFull);
        sensor.AddObservation(transform.forward);
        //Total 4 values
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("bush"))
        {
            EatBush(collision.gameObject);
        }
    }

    private void EatBush(GameObject bushObject)
    {
        if (isFull) return;//**This determines that it cant eat more than one, need to change this for reproduction
        isFull = true;

        grasslandArea.RemoveSpecificBush(bushObject);
        AddReward(1f);
        OnEpisodeBegin();
    }


}
