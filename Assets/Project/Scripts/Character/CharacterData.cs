using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]

public class CharacterData : ScriptableObject
{
    public string characterName;
    public int statMaxHP;
    public GameObject characterModelPrefab;

    public int statATK;
    public GameObject enemyAttackEffect;
    public Sprite playerStandingImage;

    public List<Card> playerDefaultDeck;

    public bool isUnlock = true;
}
