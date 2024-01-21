using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    private int _highestItemIdCollected = 0;
    private void Update()
    {
        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.GetComponent<ItemHandler>() != null)
        {
            if (other.gameObject.GetComponent<ItemHandler>().id <= _highestItemIdCollected)
            {
                _highestItemIdCollected++;
                Destroy(other.gameObject);
            }
        }*/
    }

}
