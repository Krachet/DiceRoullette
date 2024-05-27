using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] public Healthbar healthbar;
    [SerializeField] public Healthbar targetHealthbar;
    public CharactersStats charactersStats;
    public float attackStat;
    public float defenseStat;
    public float magicStat;
    public float luckStat;
    public virtual void OnInit()
    {
        BattleSystem.currentCharTurn = this;
    }

    public virtual void DealDamage(float damage)
    {
        targetHealthbar.SetHp(targetHealthbar.GetHp() - damage);
    }

    public abstract void OnEndTurn();
}
