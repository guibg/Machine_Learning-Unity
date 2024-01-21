using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGame : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _item;
    [SerializeField] private Vector2 _floorSize;

    private void Start()
    {
        //StartGame();
    }

    public GameObject[] StartGame()
    {
        Vector3 itemRandomPosition = new Vector3(Random.Range(-_floorSize.x, _floorSize.x), 0.5f, Random.Range(-_floorSize.y, _floorSize.y));
        GameObject item = Instantiate(_item, this.transform.parent, false);
        item.transform.localPosition = itemRandomPosition;
        item.GetComponent<Renderer>().material.color = Color.red;
        item.GetComponent<ItemHandler>().id = 0;
        itemRandomPosition = new Vector3(Random.Range(-_floorSize.x, _floorSize.x), 0.5f, Random.Range(-_floorSize.y, _floorSize.y));
        GameObject item2 = Instantiate(_item, this.transform.parent, false);
        item2.transform.localPosition = itemRandomPosition;
        item2.GetComponent<Renderer>().material.color = Color.green;
        item2.GetComponent<ItemHandler>().id = 1;
        itemRandomPosition = new Vector3(Random.Range(-_floorSize.x, _floorSize.x), 0.5f, Random.Range(-_floorSize.y, _floorSize.y));
        GameObject item3 = Instantiate(_item, this.transform.parent, false);
        item3.transform.localPosition = itemRandomPosition;
        item3.GetComponent<Renderer>().material.color = Color.blue;
        item3.GetComponent<ItemHandler>().id = 2;

        Vector3 playerRandomPosition = new Vector3(Random.Range(-_floorSize.x, _floorSize.x), 1f, Random.Range(-_floorSize.y, _floorSize.y));
        _player.transform.localPosition = playerRandomPosition;

        GameObject[] items = new GameObject[3];
        items[0] = item;
        items[1] = item2;
        items[2] = item3;

        return items;
    }
}