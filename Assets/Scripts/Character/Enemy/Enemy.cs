using DamageNumbersPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Character player;
    public DamageNumber numberPrefab;
    public RectTransform rectParent;

    private void Start()
    {
        this.attackStat = charactersStats.attackStats;
        this.defenseStat = charactersStats.defenseStats;
        this.magicStat = charactersStats.magicStats;
        healthbar.OnInit(100);
    }

    public override void OnInit()
    {
        base.OnInit();
        DealDamage(50 + attackStat);
        Invoke(nameof(OnEndTurn), 1);
    }

    public override void DealDamage(float damage)
    {
        base.DealDamage(damage);
        numberPrefab.SpawnGUI(rectParent, Vector2.zero, damage);
    }

    public override void OnEndTurn()
    {
        player.OnInit();
    }
}
