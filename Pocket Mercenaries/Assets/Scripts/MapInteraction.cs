using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapInteraction : MonoBehaviour
{
    [SerializeField] Transform[] regions = new Transform[10];
    private Transform destination;
    private GameObject player;
    private string regionName;

    private void Start() {
        player = GameObject.Find("Player");

        regions[0] = GameObject.Find("Green1").transform;
        regions[1] = GameObject.Find("White1").transform;
        regions[2] = GameObject.Find("Brown1").transform;
        regions[3] = GameObject.Find("Green2").transform;
        regions[4] = GameObject.Find("White2").transform;
        regions[5] = GameObject.Find("Brown2").transform;
        regions[6] = GameObject.Find("Green3").transform;
        regions[7] = GameObject.Find("Brown3").transform;
        regions[8] = GameObject.Find("White3").transform;
        regions[9] = GameObject.Find("Start1").transform;
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                destination = hit.collider.gameObject.transform;
                regionName = hit.collider.gameObject.name;
                Debug.Log("I got " + hit.collider.gameObject.name);
                PathFinder(regionName);
            }
        }
    }


    private void PathFinder(string name) 
    {
        switch (name)
        {
            case "StartPoint1TileMap": 
                player.transform.position = regions[9].position;
                break;
            case "Greeen1TileMap":
                player.transform.position = regions[0].position;
                break;
            case "Brown1TileMap":
                player.transform.position = regions[2].position;
                break;
            case "White1TileMap":
                player.transform.position = regions[1].position;
                break;
            case "Green2TileMap":
                player.transform.position = regions[3].position;
                break;
            case "Brown2TileMap":
                player.transform.position = regions[5].position;
                break;
            case "White2TileMap":
                player.transform.position = regions[4].position;
                break;
            case "Green3TileMap":
                player.transform.position = regions[6].position;
                break;
            case "Brown3TileMap":
                player.transform.position = regions[7].position;
                break;
            case "White3TileMap":
                player.transform.position = regions[8].position;
                break;
            default: 
                player.transform.position = regions[9].position;
                break;
        }
    }

}
