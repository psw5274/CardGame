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
    [SerializeField]
    public Character playerCharacter;
    [SerializeField]
    public Character enemyCharacter;

    [SerializeField]
    public Team currentTurn;
    private Dictionary<Team, Character> currentTurnCharacter;


    public void OnTurnBegin()
    {
        currentTurn = currentTurn == Team.Player ? Team.Enemy : Team.Player;

        currentTurnCharacter[currentTurn].OnTurnBegin();
    }

    public void OnTurnEnd()
    {
        currentTurnCharacter[currentTurn].OnTurnEnd();
    }

    private void Start()
    {
        currentTurn = Team.Player;
        currentTurnCharacter.Add(Team.Player, playerCharacter);
        currentTurnCharacter.Add(Team.Enemy, enemyCharacter);
    }
}