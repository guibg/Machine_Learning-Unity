using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToGoalAgent : Agent
{
    private Transform target1Transform;
    private Transform target2Transform;
    private Transform target3Transform;
    private GameObject[] items = new GameObject[3];
    private int _highestItemIdCollected = 0;
    [SerializeField] private CreateGame createGame;
    [SerializeField] Material _floorWin;
    [SerializeField] Material _floorLose;
    [SerializeField] private MeshRenderer _floor;
    public override void OnEpisodeBegin()
    {
        DestroyItems();
        items = createGame.StartGame();
        target1Transform = items[0].transform;
        target2Transform = items[1].transform;
        target3Transform = items[2].transform;
        _highestItemIdCollected = 0;
        print("Episode Begin: " + _highestItemIdCollected);
        //StartCoroutine(PenalizeForTime());
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        if (_highestItemIdCollected == 0)
        {
            sensor.AddObservation(transform.localPosition - target1Transform.localPosition);
        }
        else if (_highestItemIdCollected == 1)
        {
            sensor.AddObservation(transform.localPosition - target2Transform.localPosition);
        }
        else
        {
            sensor.AddObservation(transform.localPosition - target3Transform.localPosition);
        }
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.DiscreteActions[0];
        float moveZ = actions.DiscreteActions[1];
        float speed = 4f;
        transform.Translate(new Vector3(moveX - 1, 0, moveZ - 1) * speed * Time.deltaTime);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = 1;
        discreteActionsOut[1] = 1;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            discreteActionsOut[1] = 2;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            discreteActionsOut[1] = 0;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            discreteActionsOut[0] = 0;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            discreteActionsOut[0] = 2;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            AddReward(-3f);
            //_floor.material = _floorLose;
            EndEpisode();
            return;
        }
        if (other.gameObject.GetComponent<ItemHandler>() != null)
        {
            if (other.gameObject.GetComponent<ItemHandler>().id <= _highestItemIdCollected)
            {
                _highestItemIdCollected++;
                AddReward(_highestItemIdCollected);
                Destroy(other.gameObject);
                if (_highestItemIdCollected == 3)
                {
                    //StopCoroutine(PenalizeForTime());
                    //_floor.material = _floorWin;
                    EndEpisode();
                }
            }
        }
    }

    private IEnumerator PenalizeForTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            AddReward(-0.01f);
        }
    }

    private void DestroyItems()
    {
        foreach (var item in items)
        {
            Destroy(item);
        }
    }

}
