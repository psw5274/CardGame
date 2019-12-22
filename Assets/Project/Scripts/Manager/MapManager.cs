using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : Manager<MapManager>
{
    public GameObject MapUI;
    public GameObject nodeMarker;
    public MapNode currentNode;
    public MapNode initNode;
    public bool isMovable = true;

    [SerializeField]
    public string currentNodeStr;
    [SerializeField]
    public string initNodeStr;

    private void Awake()
    {
    }

    private void Start()
    {
        isMovable = true;

        if (PlayerPrefs.GetString("currentNodeStr").Length > 0)
            MapManager.Instance.currentNodeStr = PlayerPrefs.GetString("currentNodeStr");
        if (PlayerPrefs.GetString("initNodeStr").Length > 0)
            MapManager.Instance.initNodeStr = PlayerPrefs.GetString("initNodeStr");

        if (MapManager.Instance.currentNodeStr.Length > 0)
        {
                currentNode = GameObject.Find(currentNodeStr.Split(' ')[0]).GetComponent<MapNode>();
        }
        if (MapManager.Instance.initNodeStr.Length > 0)
        {
            initNode = GameObject.Find(initNodeStr.Split(' ')[0]).GetComponent<MapNode>();
        }

        if(initNode == null)
            initNode = GameObject.Find("Stage0").GetComponent<MapNode>();
        if (currentNode == null)
            currentNode = GameObject.Find("Stage0").GetComponent<MapNode>();


        SetMarker(currentNode);
    }

    public void SetMarker(MapNode node)
    {
        Vector3 vec = nodeMarker.transform.localPosition;
        nodeMarker.transform.SetParent(node.gameObject.transform);
        nodeMarker.transform.localPosition = vec;
    }
}
