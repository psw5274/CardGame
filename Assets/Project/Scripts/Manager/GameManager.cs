using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 전역적인 게임 데이터에 대한 매니저 클래스
// 여러 스테이지의 컨트롤을 위함



public class GameManager : Manager<GameManager>
{
    [SerializeField]
    public CharacterData playerCharacter;

    [SerializeField]
    public CharacterData enemyCharacter;

    // Global Player Status
    public int numBattleEndReward = 3;

    // Global Player Status

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetPlayerCharacter(CharacterData character)
    {
        playerCharacter = character;
    }

    public void SetEnemyCharacter(CharacterData data)
    {
        enemyCharacter = data;
    }

    public void SetBattle()
    {
        //BattleManager.Instance.SetBattleData(playerCharacter, enemyCharacter);
        SceneManager.LoadScene("Battle");
    }

    public void EndBattle(bool isWin)
    {
        SceneManager.LoadScene("BattleEnd");

        Debug.Log("END BATTLE" + isWin);
    }
}
