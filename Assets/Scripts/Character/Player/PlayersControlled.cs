using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersControlled : Character
{
    [SerializeField] private Camera mouseCamera;
    public Character enemy;

    private int cornerIndex;
    public override void OnInit()
    {
        base.OnInit();
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        this.attackStat = charactersStats.attackStats;
        this.defenseStat = charactersStats.defenseStats;
        this.magicStat = charactersStats.magicStats;    
        this.luckStat = charactersStats.luckStats;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            GameController.Instance.onCornerChoose();
            RollDice.Instance.ButtonFlipSwitch(true);
        }
        if (collision.gameObject.tag == "FinalTile")
        {
            GameController.Instance.onFinalTile();
        }
    }

    public override void OnEndTurn()
    {
        enemy.OnInit();
    }
}
