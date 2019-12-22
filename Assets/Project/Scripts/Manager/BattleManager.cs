using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Player,
    Enemy
}

public class BattleManager : Manager<BattleManager>
{
    private const int MAX_COST = 9;

    [SerializeField]
    CharacterData playerCharacterData;
    [SerializeField]
    CharacterData enemyCharacterData;

    [SerializeField]
    public Character playerCharacter;
    [SerializeField]
    public Character enemyCharacter;
    
    [SerializeField]
    public Team currentTurnTeam;
    [SerializeField]
    private int currentTurnCount;

    public int playerMaxCost = 3;
    public int playerRemainCost;

    private bool isBattleEnd;

    private void Awake()
    {
        playerRemainCost = playerMaxCost;
        isBattleEnd = true;
    }
    private void Start()
    {
        playerCharacterData = GameManager.Instance.playerCharacter;
        enemyCharacterData =  GameManager.Instance.enemyCharacter;

        SetBattle();
    }

    public void SetBattleData(CharacterData player, CharacterData enemy)
    {
        playerCharacterData = player;
        enemyCharacterData = enemy;
    }

    public void SetBattle()
    {
        var tmp = GameObject.Find("PlayerPosition").transform;
        playerCharacter = Instantiate(playerCharacterData.characterModelPrefab,
                                      tmp)
                          .GetComponent<Character>();
        playerCharacter.BindCharacter(playerCharacterData);

        enemyCharacter = Instantiate(enemyCharacterData.characterModelPrefab,
                         GameObject.Find("EnemyPosition").transform)
                         .GetComponent<Character>();
        enemyCharacter.BindCharacter(enemyCharacterData);

        currentTurnCount = 0;
        isBattleEnd = false;

        DeckManager.Instance.SetNewBattleDeck();

        NewTurn();
    }

    // tmp hard coding for character checking
    private void Update()
    {
        if(!isBattleEnd && playerCharacter.IsDead())
        {
            isBattleEnd = true;
            SetWinner(Team.Enemy);
            UIManager.Instance.SetEndBattleButton(false);
        }
        else if(!isBattleEnd && enemyCharacter.IsDead())
        {
            isBattleEnd = true;
            SetWinner(Team.Player);
            UIManager.Instance.SetEndBattleButton(true);
        }

    }

    public void SetWinner(Team winningTeam)
    {
        UIManager.Instance.SetSystemDialog(winningTeam.ToString() + " Win !!", 0);
    }

    public void NewTurn()
    {
        currentTurnTeam = Team.Player;
        currentTurnCount++;

        //playerCharacter.OnTurnBegin();

        // Reset Cost On New Turn
        playerRemainCost = playerMaxCost;
        UIManager.Instance.SetCostText(playerRemainCost, playerMaxCost);

        DeckManager.Instance.DrawCard();
        DeckManager.Instance.SetHand();

        UIManager.Instance.SetTurnButton(currentTurnTeam);
        UIManager.Instance.SetSystemDialog("턴 " + currentTurnCount + "!!");
    }

    public void EndTurn()
    {
        //playerCharacter.OnTurnEnd();

        DeckManager.Instance.RemoveAllHands();
        DeckManager.Instance.RemoveAllHandObjects();

        StartEnemyTurn();
    }

    public bool UsePlayerCost(int amount)
    {
        if(amount > playerRemainCost)
        {
            return false;
        }
        else
        {
            playerRemainCost -= amount;
        }

        DeckManager.Instance.CheckCardHighlight();
        UIManager.Instance.SetCostText(playerRemainCost, playerMaxCost);

        return true;
    }

    public void StartEnemyTurn()
    {
        currentTurnTeam = Team.Enemy;
        UIManager.Instance.SetTurnButton(currentTurnTeam);

        enemyCharacter.OnTurnBegin();


        StartCoroutine(EnemyTurnCoroutine());
    }
    IEnumerator EnemyTurnCoroutine()
    {

        // tmp enemy turn timer
        yield return new WaitForSeconds(3);
        EndEnemyTurn();
    }

    public void EndEnemyTurn()
    {
        //enemyCharacter.OnTurnEnd();
        NewTurn();
    }
}