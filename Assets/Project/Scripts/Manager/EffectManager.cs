using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class EffectManager : Manager<EffectManager>
{
    public Vector3 playerEffectPosition;
    public Vector3 enemyEffectPosition;

    private void Awake()
    {
        playerEffectPosition = GameObject.Find("PlayerEffectPosition").transform.position;
        enemyEffectPosition = GameObject.Find("EnemyEffectPosition").transform.position;
    }
}
