using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapNode : MonoBehaviour
{
    public List<MapNode> nextNodeList;
    
    [SerializeField]
    private CharacterData enemyData;

    public bool isCleared = false;

    public void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(MoveToBattle);
    }

    public void MoveToBattle()
    {
        if (MapManager.Instance.currentNode.nextNodeList.Contains(this) ||
            MapManager.Instance.initNode == this)
        {
            MapManager.Instance.currentNode = this;
            MapManager.Instance.SetMarker(this);

            this.isCleared = true;

            GameManager.Instance.SetEnemyCharacter(this.enemyData);

            PlayerPrefs.SetString("currentNodeStr", MapManager.Instance.currentNode.ToString());
            PlayerPrefs.SetString("initNodeStr", MapManager.Instance.initNode.ToString());
            PlayerPrefs.Save();
            GameManager.Instance.SetBattle();
        }
    }
}
